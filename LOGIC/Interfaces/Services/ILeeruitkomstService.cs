using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Services
{
    public interface ILeeruitkomstService
    {
        Task<ResultObject<Leeruitkomst>> AddLeeruitkomst(Leeruitkomst leeruitkomst);
        Task<ResultObject<Leeruitkomst>> GetLeeruitkomstById(int leeruitkomstId);
        Task<ResultObject<Leeruitkomst>> UpdateLeeruitkomst(Leeruitkomst leeruitkomst);
        Task<ResultObject<Leeruitkomst>> DeleteLeeruitkomst(int leeruitkomstId);
        Task<ResultObject<List<Leeruitkomst>>> GetLeeruitkomstenByEvlId(int evlId);
    }
}
