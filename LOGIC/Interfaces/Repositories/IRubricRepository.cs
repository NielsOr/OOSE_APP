using LOGIC.Models;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Repositories
{
    public interface IRubricRepository
    {
        Task<Rubric> Create(Rubric rubric);
        Task<Rubric> Read(int id);
        Task<Rubric> Update(int id, Rubric rubric);
        Task<bool> Delete(int id);
    }
}
