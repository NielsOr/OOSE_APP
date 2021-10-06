using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IEvl_Service
    {
        Task<ResultObject<List<EvlModel>>> GetEvls();
        Task<ResultObject<EvlModel>> AddEvl(string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten);
        Task<ResultObject<EvlModel>> GetEvlById(int id);
        Task<ResultObject<EvlModel>> UpdateEvl(int id, string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten);
        Task<ResultObject<EvlModel>> DeleteEvl(int id);
    }
}
