using LOGIC.Models;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Services
{
    public interface ITentamineringService
    {
        Task<ResultObject<Tentaminering>> CreateTentaminering(Tentaminering tentaminering);
        Task<ResultObject<Tentaminering>> ReadTentaminering(int id);
        Task<ResultObject<Tentaminering>> UpdateTentaminering(int id, Tentaminering tentaminering);
        Task<ResultObject<bool>> DeleteTentaminering(int id);
        Task<ResultObject<FileResultObject>> DownloadRubrics(int id, int contentType);
    }
}
