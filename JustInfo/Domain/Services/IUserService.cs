using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustInfo.Domain.Communications;
using JustInfo.Domain.Models;
using JustInfo.Helpers.Mappings;
using JustInfo.UIResources.UIOutput;

namespace JustInfo.Domain.Services
{
    public interface IUserService
    {
        Task<UserInfo> FindUserById(string id);
        Task<UserResponse> UpdateAsync(string id, UserInfo user);
    }
}
