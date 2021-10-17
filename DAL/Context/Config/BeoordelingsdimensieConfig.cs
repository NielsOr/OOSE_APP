using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class BeoordelingsdimensieConfig : IEntityTypeConfiguration<Beoordelingsdimensie>
    {
        public void Configure(EntityTypeBuilder<Beoordelingsdimensie> builder)
        {
            //TABLE
            builder.ToTable("beoordelingsdimensie");
            //PK
            builder.HasKey(dimensie => dimensie.Id);
            builder.Property(dimensie => dimensie.Id).UseIdentityColumn(1, 1).IsRequired();
            //FK
            builder.Property(dimensie => dimensie.TentamineringId).IsRequired(true);
            //COLUMNS
            builder.Property(dimensie => dimensie.Naam).IsRequired(true).HasMaxLength(100);
            builder.Property(dimensie => dimensie.Code).IsRequired(true).HasMaxLength(100);
            builder.Property(dimensie => dimensie.Weging).IsRequired(true);
            builder.Property(dimensie => dimensie.MinimaalOordeel).IsRequired(true);
            builder.Property(dimensie => dimensie.Beschrijving).IsRequired(false).HasMaxLength(300);
            //RELATIONS
            /*builder.HasMany(dimensie => dimensie.Beoordelingscriteria)
                   .WithOne(criterium => criterium.Beoordelingsdimensie)
                   .HasForeignKey(criterium => criterium.Id)
                   .OnDelete(DeleteBehavior.Restrict); // te bepalen

            builder.HasOne(dimensie => dimensie.Tentaminering)
                   .WithMany(tentaminering => tentaminering.Beoordelingsdimensies)
                   .HasForeignKey(dimensie => dimensie.Id)
                   .OnDelete(DeleteBehavior.Restrict); // te bepalen*/
        }
    }
}
