using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustInfo.Domain.IRepositories;
using JustInfo.Domain.Models;
using JustInfo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JustInfo.Persistence.Repositories
{
    public class ScrapRepository : BaseRepository, IScrapRepository
    {
        public ScrapRepository(JustInfoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Scrap>> ListAsync()
        {
            return await _context.Scraps.ToListAsync();
        }

        public async Task<IEnumerable<Scrap>> ScrapsByUserId(string id)
        {
            return await _context.Scraps.Where(s => s.IdentityId == id).ToListAsync();
        }

        public async Task AddAsync(Scrap Scrap)
        {
            await _context.Scraps.AddAsync(Scrap);
        }

        public async Task<Scrap> FindByIdAsync(string id)
        {
            return await _context.Scraps.FindAsync(id);
        }

        public void Update(Scrap Scrap)
        {
            _context.Scraps.Update(Scrap);
        }

        public void Remove(Scrap Scrap)
        {
            _context.Scraps.Remove(Scrap);
        }
    }
}
