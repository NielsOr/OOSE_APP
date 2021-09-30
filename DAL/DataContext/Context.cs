using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.DataContext
{
    public class Context : DbContext
    {
       
        // We want the DatabaseContext to expect to have an DbContextOptions object available when it is created:
        // So We have set a static OptionsBuild Constructor:
        // SO IN  OTHER WORDS: 
        // A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced
        public static ContextOptions Options = new ContextOptions();

        //DatabaseContext CONSTRUCTOR:
        // Initializes a new instance of DbContext (DatabaseContext) but with specified OPTIONS.
        // But we will always simply just use the static OptionsBuild Options, as they are static and ready to go.
        public Context(DbContextOptions<Context> options) : base(options) { }

        //Our DbSets [Entities].
        //public DbSet<Applicant> Applicants { get; set; }
        //public DbSet<Application> Applications { get; set; }
        //public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        //public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime modifiedDate = new DateTime(1900, 1, 1);

        }
    }
}