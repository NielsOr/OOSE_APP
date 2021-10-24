using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IEvlRepository : ICrudRepository
    {
        Task<Evl> GetEvlById(int EvlId);
    }
}
