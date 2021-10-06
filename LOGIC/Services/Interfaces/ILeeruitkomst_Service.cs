using LOGIC.Models;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface ILeeruitkomst_Service
    {
        Task<ResultObject<LeeruitkomstModel>> AddLeeruitkomst(int evlId, string naam, string beschrijving);
        Task<ResultObject<LeeruitkomstModel>> GetLeeruitkomstById(int leeruitkomstId); 
        Task<ResultObject<LeeruitkomstModel>> UpdateLeeruitkomst(int leeruitkomstId, string naam, string beschrijving);
        Task<ResultObject<LeeruitkomstModel>> DeleteLeeruitkomst(int leeruitkomstId);
    }
}
