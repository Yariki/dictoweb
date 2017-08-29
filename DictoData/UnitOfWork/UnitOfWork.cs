using System;
using System.Collections;
using System.Threading.Tasks;
using DictoData.Context;
using DictoData.Core;
using DictoData.Interfaces;

namespace DictoData.UnitOfWork
{ 
    public class UnitOfWork : IDisposable
    {
        private DictoContext _context;
        protected Hashtable _repositories;

        private bool _isDisposed;

        public UnitOfWork(DictoContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICoreRepository<T> Repository<T>() where T : CoreEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var name = typeof(T).Name;
            if (_repositories.ContainsKey(name))
            {
                return _repositories[name] as ICoreRepository<T>;
            }

            var type = typeof(CoreRepository<>);
            _repositories.Add(name, Activator.CreateInstance(type.MakeGenericType(typeof(T)),_context));

            return (ICoreRepository<T>) _repositories[name];
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        private void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (isDisposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
                if (_repositories != null)
                {
                    _repositories.Clear();
                    _repositories = null;
                }
            }
        }
        
    }
}