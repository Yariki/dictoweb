using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictoData.Context;
using DictoData.Model;
using DictoData.UnitOfWork;
using DictoInfrasctructure.Core;
using DictoServices.Interfaces;
using Microsoft.Extensions.Logging;

namespace DictoServices.Services
{
    public class AccountService : CoreService, IAccountService
    {
        private UnitOfWork _unitOfWork;
        
        public AccountService(DictoContext context,ILogger<AccountService> logger)
            : base(logger)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            var users = _unitOfWork.Repository<User>();

            var user = await users.GetFilteredAsync(u => u.Email == userName);
            
            if (!user.Any())
            {
                return null;
            }

            return VerifyPassword(password, user.FirstOrDefault().Password) ? user.FirstOrDefault() : null;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw  new ArgumentException("Password is empty");

            if(_unitOfWork.Repository<User>().Set.Any(u => u.Email == user.Email)) 
                throw new ArgumentException($"Username: {user.Email} is already exist.");

            var passwordMd5 = CalculateMD5Hash(password);
            user.Password = passwordMd5;

            _unitOfWork.Repository<User>().Insert(user);
            _unitOfWork.SaveChanges();
            return user;
        }
        

        private bool VerifyPassword(string currentPassword, string userPasswordHash)
        {
            return CalculateMD5Hash(currentPassword) == userPasswordHash;
        }

        private string CalculateMD5Hash(string password)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var bytes = System.Text.Encoding.ASCII.GetBytes(password);

            byte[] hash = md5.ComputeHash(bytes);

            var str = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                str.Append(hash[i].ToString("x2"));
            }

            return str.ToString();
        }
        
    }
}