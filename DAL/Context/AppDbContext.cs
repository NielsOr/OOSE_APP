using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {

        // We want to pass our DbContextOptions to the DbContext before it is created
        // So we create a static AppDbContextOptions to initialize the DbContextOptions before the first instance of DbContext is created or any static members are referenced.
        public static AppDbContextOptions AppDbContextOptions = new AppDbContextOptions();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Beoordelingsdimensie> Beoordelingsdimensies { get; set; }
        public DbSet<Evl> Evls { get; set; }
        public DbSet<Leeruitkomst> Leeruitkomsten { get; set; }
        public DbSet<Beoordelingscriterium> Beoordelingscriteria { get; set; }
        public DbSet<Tentaminering> Tentamineringen { get; set; }


        //gebruik hier fluent api om eigenschappen van tables & kolommen te specificeren.
        //TO DO: .onDelete behaviour bepalen
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}