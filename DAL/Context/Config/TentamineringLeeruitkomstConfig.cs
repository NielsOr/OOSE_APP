using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class TentamineringLeeruitkomstConfig : IEntityTypeConfiguration<TentamineringLeeruitkomst>
    {
        public void Configure(EntityTypeBuilder<TentamineringLeeruitkomst> builder)
        {
            //TABLE
            builder.ToTable("tentaminering_leeruitkomst");
            //PK
            builder.HasKey(tentamineringleeruitkomst => tentamineringleeruitkomst.Id);
            builder.Property(tentamineringleeruitkomst => tentamineringleeruitkomst.Id).UseIdentityColumn(1, 1).IsRequired();
            //FK
            builder.Property(tentamineringleeruitkomst => tentamineringleeruitkomst.TentamineringId).IsRequired(true);
            builder.Property(tentamineringleeruitkomst => tentamineringleeruitkomst.LeeruitkomstId).IsRequired(true);
            //COLUMNS
            builder.Property(tentaminering => tentaminering.Beoordelingcriteria).IsRequired(true).HasMaxLength(300);
        }    
    }
}
