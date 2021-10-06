using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Context
{
    //Allows for db migrations and db structure updates and changes from this DAL project
  
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        //Create a DatabaseContext which must be used when performing a database migration.
        //Returns a DatabaseContext with all required db connection info
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("sql"));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
