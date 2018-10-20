using System.Threading.Tasks;
using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IThirdLevelService : ILevelCount
    {
        Task<PazzleItemDto[]> GenerateTasksAsync(string userName);
    }
}