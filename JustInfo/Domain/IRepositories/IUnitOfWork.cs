using System;
using System.Threading.Tasks;

namespace JustInfo.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
