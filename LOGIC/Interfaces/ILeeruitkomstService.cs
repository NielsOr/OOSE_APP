using LOGIC.Models;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface ILeeruitkomstService
    {
        Task<ResultObject<Leeruitkomst>> AddLeeruitkomst(int evlId, string naam, string beschrijving);
        Task<ResultObject<Leeruitkomst>> GetLeeruitkomstById(int leeruitkomstId);
        Task<ResultObject<Leeruitkomst>> UpdateLeeruitkomst(int leeruitkomstId, string naam, string beschrijving);
        Task<ResultObject<Leeruitkomst>> DeleteLeeruitkomst(int leeruitkomstId);
    }
}
