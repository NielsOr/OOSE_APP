using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class TentamineringConfig : IEntityTypeConfiguration<Tentaminering>
    {
        public void Configure(EntityTypeBuilder<Tentaminering> builder)
        {
            //TABLE
            builder.ToTable("tentaminering");
            //PK
            builder.HasKey(tentaminering => tentaminering.Id);
            builder.Property(tentaminering => tentaminering.Id).UseIdentityColumn(1, 1).IsRequired();
            //FK
            builder.Property(tentaminering => tentaminering.EvlId).IsRequired(true);
            //COLUMNS
            builder.Property(tentaminering => tentaminering.Code).IsRequired(true).HasMaxLength(100);
            builder.Property(tentaminering => tentaminering.Naam).IsRequired(true).HasMaxLength(100);
            builder.Property(tentaminering => tentaminering.Aanmeldingstype).IsRequired(true).HasMaxLength(200);
            builder.Property(tentaminering => tentaminering.Hulpmiddelen).IsRequired(true).HasMaxLength(200);
            builder.Property(tentaminering => tentaminering.Weging).IsRequired(true);
            builder.Property(tentaminering => tentaminering.MinimaalOordeel).IsRequired(true);
            builder.Property(tentaminering => tentaminering.Tentamenvorm).IsRequired(true).HasMaxLength(200);
            //RELATIONS
            /*builder.HasOne(tentaminering => tentaminering.Evl)
                   .WithMany(evl => evl.Tentamineringen)
                   .HasForeignKey(tentamineringen => tentamineringen.EvlId);
                   //.OnDelete(DeleteBehavior.Restrict); // te bepalen

            builder.HasMany(tentaminering => tentaminering.Leeruitkomsten)
                   .WithMany(leeruitkomst => leeruitkomst.Tentamineringen);

            builder.HasMany(tentaminering => tentaminering.Beoordelingsdimensies)
                   .WithOne(dimensie => dimensie.Tentaminering)
                   .HasForeignKey(dimensie => dimensie.TentamineringId);
                   //.OnDelete(DeleteBehavior.Restrict); // te bepalen*/
        }
    }
}
