using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Repositories
{
    public interface ILeeruitkomstRepository
    {
        Task<Leeruitkomst> Create(Leeruitkomst evl);
        Task<Leeruitkomst> Read(int id);
        Task<Leeruitkomst> Update(Leeruitkomst objectToUpdate, int id);
        Task<bool> Delete(int id);

    }
}
