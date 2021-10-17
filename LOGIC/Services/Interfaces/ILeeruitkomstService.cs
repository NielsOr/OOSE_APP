using LOGIC.Models;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface ILeeruitkomstService
    {
        Task<ResultObject<LeeruitkomstDto>> AddLeeruitkomst(int evlId, string naam, string beschrijving);
        Task<ResultObject<LeeruitkomstDto>> GetLeeruitkomstById(int leeruitkomstId);
        Task<ResultObject<LeeruitkomstDto>> UpdateLeeruitkomst(int leeruitkomstId, string naam, string beschrijving);
        Task<ResultObject<LeeruitkomstDto>> DeleteLeeruitkomst(int leeruitkomstId);
    }
}
