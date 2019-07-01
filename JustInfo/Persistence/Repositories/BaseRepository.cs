using System;
using JustInfo.Persistence.Contexts;

namespace JustInfo.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly JustInfoDbContext _context;

        protected BaseRepository(JustInfoDbContext context)
        {
            _context = context;
        }
    }
}
