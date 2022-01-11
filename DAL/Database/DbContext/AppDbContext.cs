using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Database.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EvlEntity> Evls { get; set; }
        public DbSet<LeeruitkomstEntity> Leeruitkomsten { get; set; }
        public DbSet<EindkwalificatieEntity> Eindkwalificaties { get; set; }
        public DbSet<TentamineringEntity> Tentamineringen { get; set; }
        public DbSet<TentamineringLeeruitkomstEntity> TentamineringLeeruitkomsten { get; set; }
        public DbSet<RubricEntity> Rubrics { get; set; }
        public DbSet<RubricCriteriumEntity> RubricCriteria { get; set; }
        public DbSet<EvlRevisieEntity> EvlRevisies { get; set; }






        //Archieven met revisies
        /*public DbSet<RubricRevisie> RubricRevisies { get; set; }
        public DbSet<EvlRevisie> EvlRevisies { get; set; }
        public DbSet<LeeruitkomstRevisie> LeeruitkomstRevisies { get; set; }
        public DbSet<RubricCriteriumRevisie> RubricCriteriumRevisies { get; set; }
        public DbSet<TentamineringRevisie> TentamineringRevisies { get; set; }
        public DbSet<TentamineringLeeruitkomstRevisie> TentamineringLeeruitkomstenRevisies { get; set; }*/

        //gebruik hier fluent api om eigenschappen van tables & kolommen te specificeren.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}