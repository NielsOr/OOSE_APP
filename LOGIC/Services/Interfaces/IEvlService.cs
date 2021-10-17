using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IEvlService
    {
        Task<ResultObject<List<EvlDto>>> GetEvls();
        Task<ResultObject<EvlDto>> AddEvl(string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten);
        Task<ResultObject<EvlDto>> GetEvlById(int id);
        Task<ResultObject<EvlDto>> UpdateEvl(int id, string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten);
        Task<ResultObject<EvlDto>> DeleteEvl(int id);
    }
}
