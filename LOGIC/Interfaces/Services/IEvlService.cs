using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Services
{
    public interface IEvlService
    {
        Task<ResultObject<List<Evl>>> GetEvls();
        Task<ResultObject<Evl>> AddEvl(Evl evl);
        Task<ResultObject<Evl>> GetEvlById(int id);
        Task<ResultObject<Evl>> UpdateEvl(Evl evl);
        Task<ResultObject<Evl>> DeleteEvl(int id);

    }
}
