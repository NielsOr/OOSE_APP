using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Functions.Crud
{
    /// <summary>
    /// Generic based CRUD methods, Create, Read, Update, Delete methods.
    /// <para>In region: BASIC EXAMPLE WITHOUT - DI : you will find a very basic set of examples</para>
    /// </summary>
    public class Crud : ICrud
    {
        /// <summary>
        /// Create a new record of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectForDb"></param>
        /// <returns></returns>
        public async Task<T> Create<T>(T objectForDb) where T : class
        {
            try
            {
                using (var context = new AppDbContext(AppDbContext.AppDbContextOptions.DatabaseOptions))
                {
                    await context.AddAsync<T>(objectForDb);
                    await context.SaveChangesAsync();
                    return objectForDb;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get a record from the database of Type T, by passing the Id(Primary Key) of the object type you want back. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<T> Read<T>(int entityId) where T : class
        {
            try
            {
                using (AppDbContext context = new(AppDbContext.AppDbContextOptions.DatabaseOptions))
                {
                    T result = await context.FindAsync<T>(entityId);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all records from the database of Type T. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Generic List Object</returns>
        public async Task<List<T>> ReadAll<T>() where T : class
        {
            try
            {
                using (AppDbContext context = new(AppDbContext.AppDbContextOptions.DatabaseOptions))
                {
                    var result = await context.Set<T>().ToListAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update a record in the database of Type T, by passing both updated value and the primary key. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToUpdate"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<T> Update<T>(T objectToUpdate, int entityId) where T : class
        {
            try
            {
                using (var context = new AppDbContext(AppDbContext.AppDbContextOptions.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<T>(entityId);
                    if (objectFound != null)
                    {
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete a record of Type T from the database by passing the primary key value of the object you want deleted for the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<bool> Delete<T>(int entityId) where T : class
        {
            try
            {
                using (AppDbContext context = new(AppDbContext.AppDbContextOptions.DatabaseOptions))
                {
                    T recordToDelete = await context.FindAsync<T>(entityId);
                    if (recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

