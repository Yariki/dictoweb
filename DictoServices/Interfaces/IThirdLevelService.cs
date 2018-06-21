using System.Threading.Tasks;
using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IThirdLevelService
    {
        Task<PazzleItemDto[]> GenerateTasksAsync(string userName);
    }
}