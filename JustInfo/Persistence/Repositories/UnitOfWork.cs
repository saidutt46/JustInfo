using System;
using System.Threading.Tasks;
using JustInfo.Domain.IRepositories;
using JustInfo.Persistence.Contexts;

namespace JustInfo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustInfoDbContext _context;

        public UnitOfWork(JustInfoDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
