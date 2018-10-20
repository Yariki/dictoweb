using System.Collections.Generic;
using System.Threading.Tasks;
using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IFirstLevelService : ILevelCount
    {
        Task<List<TaskItemDto>> GenerateDataLevelAsync(string userName);
    }
}