using DAL.Context;
using LOGIC.Interfaces;
using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class TentamineringRepository : ITentamineringRepository
    {
        public readonly AppDbContext _dbContext;
        public TentamineringRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tentaminering> Create(Tentaminering tentaminering)
        {
            await _dbContext.AddAsync(tentaminering);
            await _dbContext.SaveChangesAsync();
            return tentaminering;
        }
        
        public async Task<Tentaminering> Read(int id)
        {
            var result = await _dbContext.Tentamineringen
                .Include(t => t.Leeruitkomsten)
                .ThenInclude(l => l.Leeruitkomst)
                .Include(t => t.Rubrics)
                .ThenInclude(r => r.Beoordelingscriteria)
                .FirstAsync(x => x.Id == id);
                
            return result;
        }

        public async Task<Tentaminering> Update(int id, Tentaminering objectToUpdate)
        {
            var objectFound = await _dbContext.Tentamineringen.Where(x => x.Id == id).Include(x => x.Leeruitkomsten).SingleAsync();
            if (objectFound != null)
            {
                objectFound.Naam            = objectToUpdate.Naam;
                objectFound.Code            = objectToUpdate.Code;
                objectFound.Aanmeldingstype = objectToUpdate.Aanmeldingstype;
                objectFound.Hulpmiddelen    = objectToUpdate.Hulpmiddelen;
                objectFound.Weging          = objectToUpdate.Weging;
                objectFound.MinimaalOordeel = objectToUpdate.MinimaalOordeel;
                objectFound.Tentamenvorm    = objectToUpdate.Tentamenvorm;
                objectFound.Leeruitkomsten  = objectToUpdate.Leeruitkomsten;
                await _dbContext.SaveChangesAsync();
            }
            return objectFound;
        }

        public async Task<bool> Delete(int id)
        {
            var recordToDelete = await _dbContext.Tentamineringen.FirstAsync(x => x.Id == id);
            if (recordToDelete != null)
            {
                _dbContext.Remove(recordToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
