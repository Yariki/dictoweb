using System.Threading.Tasks;
using DictoData.Model;

namespace DictoServices.Interfaces
{
    public interface IAccountService
    {
        Task<User> Authenticate(string userName, string password);
        User Create(User user, string password);
    }
}