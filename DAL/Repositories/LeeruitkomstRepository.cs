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
    public class LeeruitkomstRepository : ILeeruitkomstRepository
    {
        public readonly AppDbContext _dbContext;

        public LeeruitkomstRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Leeruitkomst> Create(Leeruitkomst leeruitkomst)
        {
            await _dbContext.AddAsync(leeruitkomst);
            await _dbContext.SaveChangesAsync();
            return leeruitkomst;
        }

        public async Task<Leeruitkomst> Read(int id)
        {
            return await _dbContext.Leeruitkomsten.FirstAsync(x => x.Id == id);
        }

        public async Task<Leeruitkomst> Update(Leeruitkomst objectToUpdate, int id)
        {
            var objectFound = await _dbContext.Leeruitkomsten.FirstAsync(x => x.Id == id);
            if (objectFound != null)
            {
                objectFound.Naam = objectToUpdate.Naam;
                objectFound.Beschrijving = objectToUpdate.Beschrijving;
                await _dbContext.SaveChangesAsync();
            }
            return objectFound;
        }

        public async Task<bool> Delete(int id)
        {
            var recordToDelete = await _dbContext.Leeruitkomsten.FirstAsync(x => x.Id == id);
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
