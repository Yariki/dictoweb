using System.Threading.Tasks;

namespace DictoServices.Interfaces
{
    public interface ILevelCount
    {
        Task<int> GetCount(string userName);
    }
}