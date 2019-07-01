using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Domain.Communications;
using JustInfo.Domain.Models;

namespace JustInfo.Domain.Services
{
    public interface IScrapService
    {
        Task<IEnumerable<Scrap>> ListAsync();
        Task<IEnumerable<Scrap>> ScrapsByUserId(string id);
        Task<ScrapResponse> SaveAsync(Scrap scrap);
        Task<ScrapResponse> UpdateAsync(int id, Scrap scrap);
        Task<ScrapResponse> DeleteAsync(int id);
    }
}
