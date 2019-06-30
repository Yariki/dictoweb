using System.Threading.Tasks;
using DictoInfrasctructure.Dtos;

namespace DictoServices.Interfaces
{
    public interface IMemoryService
    {
        Task<MemoryInfoDto> GetStatistics(string userName);
        Task<MemoryRepeatResultDto> GenerateRepetition(MemoryRepeatQueryDto query, string userName);
    }
}