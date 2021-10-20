using DAL.Context;
using LOGIC.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    /// <summary>
    /// Generic based CRUD methods, Create, Read, Update, Delete methods.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create<T>(T objectForDb) where T : class
        {
            try
            {
                await _dbContext.AddAsync<T>(objectForDb);
                await _dbContext.SaveChangesAsync();
                return objectForDb;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Read<T>(int entityId) where T : class
        {
            try
            {
                T result = await _dbContext.FindAsync<T>(entityId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<T>> ReadAll<T>() where T : class
        {
            try
            {
                var result = await _dbContext.Set<T>().ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Update<T>(T objectToUpdate, int entityId) where T : class
        {
            try
            {
                var objectFound = await _dbContext.FindAsync<T>(entityId);
                if (objectFound != null)
                {
                    _dbContext.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                    await _dbContext.SaveChangesAsync();
                }
                return objectFound;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete<T>(int entityId) where T : class
        {
            try
            {
                T recordToDelete = await _dbContext.FindAsync<T>(entityId);
                if (recordToDelete != null)
                {
                    _dbContext.Remove(recordToDelete);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}

