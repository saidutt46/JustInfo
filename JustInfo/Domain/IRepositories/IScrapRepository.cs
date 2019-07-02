using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Domain.Models;

namespace JustInfo.Domain.IRepositories
{
    public interface IScrapRepository
    {
        Task<IEnumerable<Scrap>> ListAsync();
        Task<IEnumerable<Scrap>> ScrapsByUserId(string id);
        Task AddAsync(Scrap scrap);
        Task<Scrap> FindByIdAsync(string id);
        void Update(Scrap scrap);
        void Remove(Scrap scrap);
    }
}
