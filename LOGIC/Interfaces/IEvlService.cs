using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IEvlService
    {
        Task<ResultObject<List<Evl>>> GetEvls();
        Task<ResultObject<Evl>> AddEvl(string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten);
        Task<ResultObject<Evl>> GetEvlById(int id);
        Task<ResultObject<Evl>> UpdateEvl(int id, string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten);
        Task<ResultObject<Evl>> DeleteEvl(int id);
    }
}
