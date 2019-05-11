using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Core;
using DictoData.Interfaces;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Exceptions;
using DictoInfrasctructure.Extensions;
using DictoServices.Interfaces;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services.Core
{
    public abstract class CoreCrudService<M, T> : CoreService, ICrudService<M,T>
        where M : CoreEntity
        where T : new()

    {
        protected IUnitOfWork UnitOfWork;
        protected IMapper Mapper;

        protected CoreCrudService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(logger)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public abstract Task<IEnumerable<T>> Get(string userName);


        public async Task<bool> AddItem(string userName, T modelDto)
        {
            var user = await GetUser(userName);
            if (user.IsNull())
            {
                throw new NotFoundItemException("USer wasn't found.");
            }

            var model = Mapper.Map<M>(modelDto);
            if (model.IsNull())
            {
                throw new NotMappedItemException($"Object with type {typeof(M).Name} could not be mapped.");
            }

            UpdateItem(user, model, modelDto);
            UnitOfWork.Repository<M>().Insert(model);
            UnitOfWork.SaveChanges();

            return true;
        }

        protected abstract void UpdateItem(User user, M model, T transportModel);
        
        

        public bool UpdateItem(T modelDto)
        {
            var updatedModel = Mapper.Map<M>(modelDto);
            if (updatedModel.IsNull())
            {
                throw new NotMappedItemException($"Object with type {typeof(M).Name} could not be mapped.");
            }
            UnitOfWork.Repository<M>().Update(updatedModel);
            UnitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteItem(T modelDto)
        {
            var deletedModel = Mapper.Map<M>(modelDto);
            if (deletedModel.IsNull())
            {
                throw new NotMappedItemException($"Object with type {typeof(M).Name} could not be mapped.");
            }

            UnitOfWork.Repository<M>().Delete(deletedModel);
            UnitOfWork.SaveChanges();
            return true;
        }

        protected async Task<User> GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }

            var users = await UnitOfWork.Repository<User>().GetFilteredAsync(user => user.Email == userName);
            if (users == null || !users.Any())
            {
                throw new KeyNotFoundException($"User {userName} wasn't found");
            }

            return users.First();
        }

    }
}