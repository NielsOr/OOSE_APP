using DAL.Context;
using LOGIC.Interfaces;
using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class EvlRepository : IEvlRepository
    {
        public readonly AppDbContext _dbContext;

        public EvlRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Evl> Create(Evl evl)
        {
            await _dbContext.AddAsync(evl);
            await _dbContext.SaveChangesAsync();
            return evl;
        }

        public async Task<Evl> Read(int id)
        {
            var result = await _dbContext.Evls.FirstAsync(x => x.Id == id);
            _dbContext.Entry(result).Collection(x => x.Tentamineringen).Load();
            _dbContext.Entry(result).Collection(x => x.Leeruitkomsten).Load();
            return result;
        }

        public async Task<Evl> Update(int id, Evl objectToUpdate)
        {
            var objectFound = await _dbContext.Evls.FirstAsync(x => x.Id == id);
            if (objectFound != null)
            {
                _dbContext.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            return objectFound;
        }

        public async Task<bool> Delete(int id)
        {
            var recordToDelete = await _dbContext.Evls.FirstAsync(x => x.Id == id);
            if (recordToDelete != null)
            {
                _dbContext.Remove(recordToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Evl>> ReadAll()
        {
            return await _dbContext.Evls.ToListAsync();
        }

        public async Task<List<Evl>> Reviseer()
        {
            return await _dbContext.Evls.ToListAsync();
        }

    }
}
