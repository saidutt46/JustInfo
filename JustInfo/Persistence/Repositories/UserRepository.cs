using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustInfo.Domain.IRepositories;
using JustInfo.Domain.Models;
using JustInfo.Persistence.Contexts;

namespace JustInfo.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(JustInfoDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<Scrap>> UserScraps(string id)
        {
            return await _context.Scraps.Where(s => s.IdentityId == id);
        }
    }
}
