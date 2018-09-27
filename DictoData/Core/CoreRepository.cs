using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DictoData.Context;
using DictoData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DictoData.Core
{
    public class CoreRepository<TEntity> : ICoreRepository<TEntity> where TEntity : CoreEntity
    {
        private DictoContext _context;
        private DbSet<TEntity> _set;

        public CoreRepository(DictoContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public DbSet<TEntity> Set => _set;

        
        public virtual async  Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> filter, params string[] includes )
        {
            IQueryable<TEntity> query = _set;

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync(); 
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            entity.Created = DateTime.Now;
            _set.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _set.Attach(entity);
            }
            _set.Remove(entity);
        }


        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            _set.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}