using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface ILeeruitkomstRepository : ICrudRepository
    {
        Task<List<Leeruitkomst>> GetLeeruitkomstenByEvlId(int evlId);
    }
}
