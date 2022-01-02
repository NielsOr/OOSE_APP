using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class EvlConfig : IEntityTypeConfiguration<Evl>
    {
        public void Configure(EntityTypeBuilder<Evl> builder)
        {
            //TABLE
            builder.ToTable("evl");
            //PK
            builder.HasKey(evl => evl.Id);
            builder.Property(evl => evl.Id).UseIdentityColumn(1, 1).IsRequired();
            //COLUMNS
            builder.Property(evl => evl.Code).IsRequired(true).HasMaxLength(100);
            builder.Property(evl => evl.Naam).IsRequired(true).HasMaxLength(100);
            builder.Property(evl => evl.Beschrijving).IsRequired(true).HasMaxLength(300);
            builder.Property(evl => evl.Beroepstaken).IsRequired(true).HasMaxLength(300);
            builder.Property(evl => evl.Eindkwalificaties).IsRequired(true).HasMaxLength(300);
            builder.Property(evl => evl.Studiepunten).IsRequired(true);
            //RELATIONS
            /*builder.HasMany(evl => evl.Leeruitkomsten)
                   .WithOne(leeruitkomst => leeruitkomst.Evl)
                   .HasForeignKey(leeruitkomst => leeruitkomst.Id)
                   .OnDelete(DeleteBehavior.Restrict); // te bepalen

            builder.HasMany(evl => evl.Tentamineringen)
                   .WithOne(tentaminering => tentaminering.Evl)
                   .HasForeignKey(tentaminering => tentaminering.Id)
                   .OnDelete(DeleteBehavior.Restrict); // te bepalen*/
        }
    }
}
