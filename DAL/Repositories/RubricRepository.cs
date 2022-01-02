using DAL.Context;
using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class RubricRepository : IRubricRepository
    {
        public readonly AppDbContext _dbContext;
        public RubricRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rubric> Create(Rubric beoordelingsdimensie)
        {
            await _dbContext.Rubrics.AddAsync(beoordelingsdimensie);
            await _dbContext.SaveChangesAsync();
            return beoordelingsdimensie;
        }

        public async Task<Rubric> Read(int id)
        {
            return await _dbContext.Rubrics.Where(x => x.Id == id).Include(x => x.Beoordelingscriteria).SingleAsync();
        }

        public async Task<Rubric> Update(int id, Rubric objectToUpdate)
        {
            var objectFound = await _dbContext.Rubrics.Where(x => x.Id == id).Include(x => x.Beoordelingscriteria).SingleAsync();
            if (objectFound != null)
            {
                objectFound.Code = objectToUpdate.Code;
                objectFound.Naam = objectToUpdate.Naam;
                objectFound.Weging = objectToUpdate.Weging;
                objectFound.MinimaalOordeel = objectToUpdate.MinimaalOordeel;
                objectFound.Beschrijving = objectToUpdate.Beschrijving;
                objectFound.Beoordelingscriteria = objectToUpdate.Beoordelingscriteria;
                await _dbContext.SaveChangesAsync();
            }
            return objectFound;
        }
        public async Task<bool> Delete(int id)
        {
            var recordToDelete = await _dbContext.Rubrics.FirstAsync(x => x.Id == id);
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
