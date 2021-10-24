using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Services
{
    public interface ITentamineringService
    {
        Task<ResultObject<Tentaminering>> AddTentaminering(int evlId, string naam, string beschrijving);
        Task<ResultObject<Tentaminering>> GetTentamineringById(int tentamineringId);
        Task<ResultObject<Tentaminering>> UpdateTentaminering(int tentamineringId, string naam, string beschrijving);
        Task<ResultObject<Tentaminering>> DeleteTentaminering(int tentamineringId);
        Task<ResultObject<List<Tentaminering>>> GetTentamineringenByEvlId(int evlId);
    }
}
