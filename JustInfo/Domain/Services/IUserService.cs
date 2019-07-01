using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Domain.Models;

namespace JustInfo.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Scrap>> UserScraps(string id);
    }
}
