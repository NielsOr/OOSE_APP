using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class ContextOptions
    {
        //CONSTRUCTOR
        //Pass our c
        public ContextOptions()
        {
            config = new ContextConfig();
            OptionsBuilder = new DbContextOptionsBuilder<Context>();
            OptionsBuilder.UseSqlServer(config.DbConnectionString);
            DatabaseOptions = OptionsBuilder.Options;
        }
        public DbContextOptionsBuilder<Context> OptionsBuilder { get; set; }
        public DbContextOptions<Context> DatabaseOptions { get; set; }
        private ContextConfig config { get; set; }
        
    }
}
