using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class BeoordelingscriteriumConfig : IEntityTypeConfiguration<Beoordelingscriterium>
    {
        public void Configure(EntityTypeBuilder<Beoordelingscriterium> builder)
        {
            //TABLE
            builder.ToTable("beoordelingscriterium");
            //PK
            builder.HasKey(criterium => criterium.Id);
            builder.Property(criterium => criterium.Id).UseIdentityColumn(1, 1).IsRequired();
            //FK
            builder.Property(criterium => criterium.BeoordelingsdimensieId).IsRequired(true);
            //COLUMNS 
            builder.Property(criterium => criterium.Oordeel).IsRequired(true);
            builder.Property(criterium => criterium.Beschrijving).IsRequired(true).HasMaxLength(300);
            //RELATIONS
            /*builder.HasOne(criterium => criterium.Beoordelingsdimensie)
                    .WithMany(dimensie => dimensie.Beoordelingscriteria)
                    .HasForeignKey(criterium => criterium.BeoordelingsdimensieId)
                    .OnDelete(DeleteBehavior.Restrict); // te bepalen*/

        }
    }
}
