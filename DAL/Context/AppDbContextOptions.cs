using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Context
{
    public class AppDbContextOptions
    {
        public AppDbContextOptions()
        {
            Config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            OptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            OptionsBuilder.UseSqlServer(Config.GetConnectionString("sql"));
            DatabaseOptions = OptionsBuilder.Options;
        }
        private IConfiguration Config { get; set; }
        public DbContextOptionsBuilder<AppDbContext> OptionsBuilder { get; set; }
        public DbContextOptions<AppDbContext> DatabaseOptions { get; set; }
    }
}
