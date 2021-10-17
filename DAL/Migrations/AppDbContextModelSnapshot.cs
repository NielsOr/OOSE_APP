﻿// <auto-generated />
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LOGIC.Models.Beoordelingscriterium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeoordelingsdimensieId")
                        .HasColumnType("int");

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Oordeel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeoordelingsdimensieId");

                    b.ToTable("beoordelingscriterium");
                });

            modelBuilder.Entity("LOGIC.Models.Beoordelingsdimensie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("MinimaalOordeel")
                        .HasColumnType("float");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TentamineringId")
                        .HasColumnType("int");

                    b.Property<int>("Weging")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TentamineringId");

                    b.ToTable("beoordelingsdimensie");
                });

            modelBuilder.Entity("LOGIC.Models.Evl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beroepstaken")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Eindkwalificaties")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Studiepunten")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("evl");
                });

            modelBuilder.Entity("LOGIC.Models.Leeruitkomst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("EvlId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EvlId");

                    b.ToTable("leeruitkomst");
                });

            modelBuilder.Entity("LOGIC.Models.Tentaminering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aanmeldingstype")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EvlId")
                        .HasColumnType("int");

                    b.Property<string>("Hulpmiddelen")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("MinimaalOordeel")
                        .HasColumnType("float");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tentamenvorm")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Weging")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvlId");

                    b.ToTable("tentaminering");
                });

            modelBuilder.Entity("LeeruitkomstTentaminering", b =>
                {
                    b.Property<int>("LeeruitkomstenId")
                        .HasColumnType("int");

                    b.Property<int>("TentamineringenId")
                        .HasColumnType("int");

                    b.HasKey("LeeruitkomstenId", "TentamineringenId");

                    b.HasIndex("TentamineringenId");

                    b.ToTable("LeeruitkomstTentaminering");
                });

            modelBuilder.Entity("LOGIC.Models.Beoordelingscriterium", b =>
                {
                    b.HasOne("LOGIC.Models.Beoordelingsdimensie", "Beoordelingsdimensie")
                        .WithMany("Beoordelingscriteria")
                        .HasForeignKey("BeoordelingsdimensieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beoordelingsdimensie");
                });

            modelBuilder.Entity("LOGIC.Models.Beoordelingsdimensie", b =>
                {
                    b.HasOne("LOGIC.Models.Tentaminering", "Tentaminering")
                        .WithMany("Beoordelingsdimensies")
                        .HasForeignKey("TentamineringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tentaminering");
                });

            modelBuilder.Entity("LOGIC.Models.Leeruitkomst", b =>
                {
                    b.HasOne("LOGIC.Models.Evl", "Evl")
                        .WithMany("Leeruitkomsten")
                        .HasForeignKey("EvlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evl");
                });

            modelBuilder.Entity("LOGIC.Models.Tentaminering", b =>
                {
                    b.HasOne("LOGIC.Models.Evl", "Evl")
                        .WithMany("Tentamineringen")
                        .HasForeignKey("EvlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evl");
                });

            modelBuilder.Entity("LeeruitkomstTentaminering", b =>
                {
                    b.HasOne("LOGIC.Models.Leeruitkomst", null)
                        .WithMany()
                        .HasForeignKey("LeeruitkomstenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LOGIC.Models.Tentaminering", null)
                        .WithMany()
                        .HasForeignKey("TentamineringenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LOGIC.Models.Beoordelingsdimensie", b =>
                {
                    b.Navigation("Beoordelingscriteria");
                });

            modelBuilder.Entity("LOGIC.Models.Evl", b =>
                {
                    b.Navigation("Leeruitkomsten");

                    b.Navigation("Tentamineringen");
                });

            modelBuilder.Entity("LOGIC.Models.Tentaminering", b =>
                {
                    b.Navigation("Beoordelingsdimensies");
                });
#pragma warning restore 612, 618
        }
    }
}