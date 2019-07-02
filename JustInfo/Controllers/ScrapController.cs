using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JustInfo.Domain.Models;
using JustInfo.Domain.Services;
using JustInfo.Extensions;
using JustInfo.UIResources.UIInput;
using JustInfo.UIResources.UIOutput;
using Microsoft.AspNetCore.Mvc;

namespace JustInfo.Controllers
{
    [Route("api/[controller]")]
    public class ScrapController : Controller
    {
        private readonly IScrapService _scrapService;
        private readonly IMapper _mapper;

        public ScrapController(IScrapService scrapService, IMapper mapper)
        {
            _scrapService = scrapService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ScrapOutput>> GetAllAsync()
        {
            var scraps = await _scrapService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Scrap>, IEnumerable<ScrapOutput>>(scraps);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<ScrapOutput>> GetScrapsByUserId(string id)
        {
            var scraps = await _scrapService.ScrapsByUserId(id);
            var resources = _mapper.Map<IEnumerable<Scrap>, IEnumerable<ScrapOutput>>(scraps);

            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ScrapInput resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var scrap = _mapper.Map<ScrapInput, Scrap>(resource);
            var result = await _scrapService.SaveAsync(scrap);

            if (!result.Success)
                return BadRequest(result.Message);
            Console.WriteLine("Retruning Results back baby!!");

            var ScrapOutput = _mapper.Map<Scrap, ScrapOutput>(result.Scrap);
            return Ok(ScrapOutput);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] ScrapInput scrap)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var convertscrap = _mapper.Map<ScrapInput, Scrap>(scrap);
            var result = await _scrapService.UpdateAsync(id, convertscrap);

            if (!result.Success)
                return BadRequest(result.Message);

            var ScrapOutput = _mapper.Map<Scrap, ScrapOutput>(result.Scrap);
            return Ok(ScrapOutput);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _scrapService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var ScrapOutput = _mapper.Map<Scrap, ScrapOutput>(result.Scrap);
            return Ok(ScrapOutput);
        }
    }
}
