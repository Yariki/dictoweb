using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DictoData.Interfaces;
using DictoData.Model;
using DictoData.UnitOfWork;

namespace DictoServices.Extensions
{
    public static class DataExtensions
    {

        public async static Task<User> GetUser(this IUnitOfWork unitOfWork, string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }

            var users = await unitOfWork.Repository<User>().GetFilteredAsync(user => user.Email == userName);
            if (users == null || !users.Any())
            {
                throw new KeyNotFoundException($"User {userName} wasn't found");
            }

            return users.First();
        }


    }
}