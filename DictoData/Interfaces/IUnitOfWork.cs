using System;
using System.Threading.Tasks;
using DictoData.Core;

namespace DictoData.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICoreRepository<T> Repository<T>() where T : CoreEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}