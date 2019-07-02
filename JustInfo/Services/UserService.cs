using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Domain.Communications;
using JustInfo.Domain.IRepositories;
using JustInfo.Domain.Models;
using JustInfo.Domain.Services;
using JustInfo.Helpers.Mappings;

namespace JustInfo.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserInfo> FindUserById(string id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<UserResponse> UpdateAsync(string id, UserInfo user)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("Scrap not found.");

            existingUser.Email = user.Email;
            existingUser.ProfileName = user.ProfileName;
            existingUser.Location = user.Location;
            existingUser.Gender = user.Gender;
            existingUser.ColorTheme = user.ColorTheme;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserResponse($"An error occurred when updating the User: {ex.Message}");
            }
        }
    }
}
