using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Domain.Communications;
using JustInfo.Domain.IRepositories;
using JustInfo.Domain.Models;
using JustInfo.Domain.Services;
using JustInfo.UIResources.UIInput;

namespace JustInfo.Services
{
    public class ScrapService : IScrapService
    {
        public readonly IScrapRepository _scrapRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ScrapService(IScrapRepository scrapRepository, IUnitOfWork unitOfWork)
        {
            _scrapRepository = scrapRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Scrap>> ListAsync()
        {
            return await _scrapRepository.ListAsync();
        }

        public async Task<IEnumerable<Scrap>> ScrapsByUserId(string id)
        {
            return await _scrapRepository.ScrapsByUserId(id);
        }

        public async Task<ScrapResponse> SaveAsync(Scrap scrap)
        {
            try
            {
                await _scrapRepository.AddAsync(scrap);
                await _unitOfWork.CompleteAsync();

                return new ScrapResponse(scrap);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ScrapResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<ScrapResponse> UpdateAsync(string id, Scrap scrap)
        {
            var existingScrap = await _scrapRepository.FindByIdAsync(id);

            if (existingScrap == null)
                return new ScrapResponse("Scrap not found.");

            existingScrap.Post = scrap.Post;

            try
            {
                _scrapRepository.Update(existingScrap);
                await _unitOfWork.CompleteAsync();

                return new ScrapResponse(existingScrap);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ScrapResponse($"An error occurred when updating the Scrap: {ex.Message}");
            }
        }

        public async Task<ScrapResponse> DeleteAsync(string id)
        {
            var existingScrap = await _scrapRepository.FindByIdAsync(id);

            if (existingScrap == null)
                return new ScrapResponse("Scrap not found.");

            try
            {
                _scrapRepository.Remove(existingScrap);
                await _unitOfWork.CompleteAsync();

                return new ScrapResponse(existingScrap);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ScrapResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
