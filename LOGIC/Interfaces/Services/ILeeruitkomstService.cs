using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Services
{
    public interface ILeeruitkomstService
    {
        Task<ResultObject<Leeruitkomst>> CreateLeeruitkomst(Leeruitkomst leeruitkomst);
        Task<ResultObject<Leeruitkomst>> ReadLeeruitkomst(int leeruitkomstId);
        Task<ResultObject<Leeruitkomst>> UpdateLeeruitkomst(int id, Leeruitkomst leeruitkomst);
        Task<ResultObject<bool>> DeleteLeeruitkomst(int leeruitkomstId);
    }
}
