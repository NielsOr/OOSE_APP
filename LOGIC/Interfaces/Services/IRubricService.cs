using LOGIC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Interfaces.Services
{
    public interface IRubricService
    {
        Task<ResultObject<Rubric>> CreateRubric(Rubric rubric);
        Task<ResultObject<Rubric>> ReadRubric(int id);
        Task<ResultObject<Rubric>> UpdateRubric(int id, Rubric rubric);
        Task<ResultObject<bool>> DeleteRubric(int id);
    }
}
