using DAL.Context;
using LOGIC.Interfaces;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class EvlRepository : CrudRepository, IEvlRepository
    {
        public EvlRepository(AppDbContext dbContext) : base(dbContext){}
        
        public async Task<Evl> GetEvlById(int EvlId)
        {
            var result = await _dbContext.Evls.SingleAsync(x => x.Id == EvlId);
            _dbContext.Entry(result).Collection(x => x.Tentamineringen).Load();
            _dbContext.Entry(result).Collection(x => x.Leeruitkomsten).Load();
            return result;
        }
    }
}
