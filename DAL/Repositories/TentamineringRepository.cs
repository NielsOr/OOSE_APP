using DAL.Context;
using LOGIC.Interfaces;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class TentamineringRepository : CrudRepository, ITentamineringRepository
    {
        public TentamineringRepository(AppDbContext dbContext) : base(dbContext){}
        public async Task<List<Tentaminering>> GetTentamineringenByEvlId(int evlId)
        {
            return await _dbContext.Tentamineringen.Where(x => x.EvlId == evlId).ToListAsync();
        }
    }
}
