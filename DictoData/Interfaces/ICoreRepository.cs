using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DictoData.Core;
using Microsoft.EntityFrameworkCore;

namespace DictoData.Interfaces
{
    public interface ICoreRepository<T> where T : CoreEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> filter, params string[] includes);
        Task<T> GetByIdAsync(int id);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        DbSet<T> Set { get; }
    }
}