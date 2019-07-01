using System;
using JustInfo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustInfo.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Scrap>> UserScraps(string id);
    }
}
