using DAL.Context;
using LOGIC.Interfaces;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class LeeruitkomstRepository : CrudRepository, ILeeruitkomstRepository
    {
        public LeeruitkomstRepository(AppDbContext dbContext) : base(dbContext){}
        public async Task<List<Leeruitkomst>> GetLeeruitkomstenByEvlId(int evlId)
        {
            return await _dbContext.Leeruitkomsten.Where(x => x.EvlId == evlId).ToListAsync();
        }
    }
}
