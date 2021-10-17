using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class LeeruitkomstConfig : IEntityTypeConfiguration<Leeruitkomst>
    {
        public void Configure(EntityTypeBuilder<Leeruitkomst> builder)
        {
            //TABLE
            builder.ToTable("leeruitkomst");
            //PK
            builder.HasKey(leeruitkomst => leeruitkomst.Id);
            builder.Property(leeruitkomst => leeruitkomst.Id).UseIdentityColumn(1, 1).IsRequired();
            //FK
            builder.Property(leeruitkomst => leeruitkomst.EvlId).IsRequired(true);
            //COLUMNS
            builder.Property(leeruitkomst => leeruitkomst.Naam).IsRequired(true).HasMaxLength(100);
            builder.Property(leeruitkomst => leeruitkomst.Beschrijving).IsRequired(true).HasMaxLength(300);
            //RELATIONS
            /*builder.HasOne(leeruitkomst => leeruitkomst.Evl)
                 .WithMany(evl => evl.Leeruitkomsten)
                 .HasForeignKey(leeruitkomst => leeruitkomst.EvlId)
                 .OnDelete(DeleteBehavior.Restrict); // te bepalen*/
        }
    }
}
