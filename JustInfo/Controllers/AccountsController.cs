﻿using AutoMapper;
using JustInfo.Domain.IRepositories;
using JustInfo.Domain.Models;
using JustInfo.Helpers.AuthHelpers;
using JustInfo.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JustInfo.Extensions;
using JustInfo.Helpers.Mappings;
using JustInfo.Domain.Services;

namespace JustInfo.Controllers
{
    [Route("app/[controller]")]
    public class AccountsController : Controller
    {
        private readonly JustInfoDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IUserService _userService;

        public AccountsController(UserManager<AppUser> userManager, IJwtFactory jwtFactory,
            IMapper mapper, JustInfoDbContext appDbContext, IOptions<JwtIssuerOptions> jwtOptions,
            IUserService userService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _userService = userService;
        }

        [HttpGet("allusers")]
        public async Task<IActionResult> ListAsync()
        {
            List<UserInfo> users = await _appDbContext.UserInfo.ToListAsync();
            List<UserProfileResponse> appUsers = new List<UserProfileResponse>();
            foreach (UserInfo user in users)
            {
                var convertedUser = _mapper.Map<UserInfo, UserProfileResponse>(user);
                appUsers.Add(convertedUser);
            }
            //users.ConvertAll(new Converter<UserInfo, UserProfileResponse>(users));
            return new OkObjectResult(appUsers);
        }

        [HttpPost("{id}")]  
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var item = await _appDbContext.UserInfo.FindAsync(id);

            if (item.GetType() != typeof(UserInfo))
            {
                return BadRequest();
            }

            var newUser = await _appDbContext.UserInfo.FirstOrDefaultAsync(e => e.IdentityId == item.IdentityId);


            return new OkObjectResult(item);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.UserInfo.AddAsync(new UserInfo
                {
                    IdentityId = userIdentity.Id,
                    Location = model.Location,
                    Gender = model.Gender,
                    ColorTheme = model.ColorTheme,
                    ProfileName = model.ProfileName,
                    Email = model.Email
                }
            );
            await _appDbContext.SaveChangesAsync();

            var newUser = await _appDbContext.UserInfo.FirstOrDefaultAsync(e => e.IdentityId == userIdentity.Id);
            var resposnse = _mapper.Map<UserInfo, UserProfileResponse>(newUser);
            return Ok(resposnse);
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            var user =  await _appDbContext.UserInfo.FirstOrDefaultAsync(u => u.Email == credentials.UserName);
            if (user == null)
            {
                if (jwt != null)
                {
                    return Ok(jwt);
                }
            }
            var response = _mapper.Map<UserInfo, UserProfileResponse>(user);
            return Ok(response);

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] UserProfileResponse user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var convertUser = _mapper.Map<UserProfileResponse, UserInfo>(user);
            var result = await _userService.UpdateAsync(id, convertUser);

            if (!result.Success)
                return BadRequest(result.Message);

            var UserOutput = _mapper.Map<UserInfo, UserProfileResponse>(result.User);
            return Ok(UserOutput);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }

    }
}
