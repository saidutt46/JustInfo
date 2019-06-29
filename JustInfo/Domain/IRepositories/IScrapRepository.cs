using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Domain.Models;

namespace JustInfo.Domain.IRepositories
{
    public interface IScrapRepository
    {
        Task<IEnumerable<Scrap>> ListAsync();
        Task AddAsync(Scrap scrap);
        Task<Scrap> FindByIdAsync(int id);
        void Update(Scrap scrap);
        void Remove(Scrap scrap);
    }
}
