using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
namespace DAL.DataContext
{
    //Allows for db migrations and db structure updates and changes from this DAL project 
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<Context>
    {
        //Create a DatabaseContext which must be used when performing a database migration.
        //Returns a DatabaseContext with all required db connection info
        public Context CreateDbContext(string[] args)
        {
            ContextConfig config = new ContextConfig();
            DbContextOptionsBuilder<Context> optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(config.DbConnectionString);
            return new Context(optionsBuilder.Options);
        }
    }
}
