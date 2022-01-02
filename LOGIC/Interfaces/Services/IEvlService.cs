using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Services
{
    public interface IEvlService
    {
        Task<ResultObject<Evl>> CreateEvl(Evl evl);
        Task<ResultObject<Evl>> ReadEvl(int id);
        Task<ResultObject<Evl>> UpdateEvl(int id, Evl evl);
        Task<ResultObject<bool>> DeleteEvl(int id);
        Task<ResultObject<List<Evl>>> ReadAllEvls();
    }
}
