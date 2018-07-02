using System.Collections.Generic;
using System.Threading.Tasks;
using DictoData.Core;

namespace DictoServices.Interfaces
{
    public interface ICrudService<M,T> where M : CoreEntity where T : new()
    {
        Task<bool> AddItem(string userName, T modelDto);
        bool UpdateItem(T modelDto);
        bool DeleteItem(T modelDto);
        Task<IEnumerable<M>> Get(string userName);
    }
}