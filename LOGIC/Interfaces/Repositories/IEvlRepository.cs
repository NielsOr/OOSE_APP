using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Repositories
{
    public interface IEvlRepository
    {
        Task<Evl> Create(Evl evl);
        Task<Evl> Read(int id);
        Task<Evl> Update(int id, Evl objectToUpdate);
        Task<bool> Delete(int id);
        Task<List<Evl>> ReadAll();
    }
}
