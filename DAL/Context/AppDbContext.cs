using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Rubric> Rubrics { get; set; }
        public DbSet<Evl> Evls { get; set; }
        public DbSet<Leeruitkomst> Leeruitkomsten { get; set; }
        public DbSet<RubricCriterium> RubricCriteria { get; set; }
        public DbSet<Tentaminering> Tentamineringen { get; set; }
        public DbSet<TentamineringLeeruitkomst> TentamineringLeeruitkomsten { get; set; }

        //gebruik hier fluent api om eigenschappen van tables & kolommen te specificeren.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}