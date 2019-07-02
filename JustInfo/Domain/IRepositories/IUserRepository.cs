using System;
using JustInfo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Helpers.Mappings;

namespace JustInfo.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<UserInfo> FindByIdAsync(string id);
        void Update(UserInfo user);
    }
}
