using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustInfo.Domain.IRepositories;
using JustInfo.Domain.Models;
using JustInfo.Helpers.Mappings;
using JustInfo.Persistence.Contexts;

namespace JustInfo.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(JustInfoDbContext context): base(context)
        {
        }

        public void Update(UserInfo user)
        {
            _context.UserInfo.Update(user);
        }

        public async Task<UserInfo> FindByIdAsync(string id)
        {
            return await _context.UserInfo.FindAsync(id);
        }
    }
}
