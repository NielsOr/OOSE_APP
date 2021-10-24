using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface ITentamineringRepository : ICrudRepository
    {
        Task<List<Tentaminering>> GetTentamineringenByEvlId(int evlId);
    }
}
