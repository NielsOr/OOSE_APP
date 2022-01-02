using LOGIC.Models;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Repositories
{
    public interface ITentamineringRepository
    {
        Task<Tentaminering> Create(Tentaminering tentaminering);
        Task<Tentaminering> Read(int id);
        Task<Tentaminering> Update(int id, Tentaminering objectToUpdate);
        Task<bool> Delete(int id);
    }
}
