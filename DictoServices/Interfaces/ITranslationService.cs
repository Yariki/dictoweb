using System.Threading.Tasks;
using DictoInfrasctructure.Dtos;
using DictoServices.Data;

namespace DictoServices.Interfaces
{
    public interface ITranslationService
    {
        Task<GoogleRequestResult> Translate(TranslateQueryDto translateData);
    }
}