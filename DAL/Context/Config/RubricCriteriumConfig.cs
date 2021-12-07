using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class RubricCriteriumConfig : IEntityTypeConfiguration<RubricCriterium>
    {
        public void Configure(EntityTypeBuilder<RubricCriterium> builder)
        {
            //TABLE
            builder.ToTable("rubric_criterium");
            //PK
            builder.HasKey(criterium => criterium.Id);
            builder.Property(criterium => criterium.Id).UseIdentityColumn(1, 1).IsRequired();
            //FK
            builder.Property(criterium => criterium.RubricId).IsRequired(true);
            //COLUMNS 
            builder.Property(criterium => criterium.Oordeel).IsRequired(true);
            builder.Property(criterium => criterium.Beschrijving).IsRequired(true).HasMaxLength(300);
        }
    }
}
