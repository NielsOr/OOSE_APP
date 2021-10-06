﻿// <auto-generated />
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211001160653_InitialDBCreation")]
    partial class InitialDBCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Beoordelingscriterium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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

                    b.ToTable("Beoordelingscriteria");
                });

            modelBuilder.Entity("DAL.Entities.Beoordelingsdimensie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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

                    b.ToTable("Beoordelingsdimensies");
                });

            modelBuilder.Entity("DAL.Entities.Evl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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

                    b.ToTable("Evls");
                });

            modelBuilder.Entity("DAL.Entities.Leeruitkomst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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

                    b.ToTable("Leeruitkomsten");
                });

            modelBuilder.Entity("DAL.Entities.Tentaminering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aanmeldingstype")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EvlId")
                        .HasColumnType("int");

                    b.Property<string>("Hulpmiddelen")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<double>("MinimaalOordeel")
                        .HasMaxLength(100)
                        .HasColumnType("float");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tentamenvorm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weging")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvlId");

                    b.ToTable("Tentamineringen");
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

            modelBuilder.Entity("DAL.Entities.Beoordelingscriterium", b =>
                {
                    b.HasOne("DAL.Entities.Beoordelingsdimensie", "Beoordelingsdimensie")
                        .WithMany("Beoordelingscriteria")
                        .HasForeignKey("BeoordelingsdimensieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beoordelingsdimensie");
                });

            modelBuilder.Entity("DAL.Entities.Beoordelingsdimensie", b =>
                {
                    b.HasOne("DAL.Entities.Tentaminering", "Tentaminering")
                        .WithMany("Beoordelingsdimensies")
                        .HasForeignKey("TentamineringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tentaminering");
                });

            modelBuilder.Entity("DAL.Entities.Leeruitkomst", b =>
                {
                    b.HasOne("DAL.Entities.Evl", "Evl")
                        .WithMany("Leeruitkomsten")
                        .HasForeignKey("EvlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evl");
                });

            modelBuilder.Entity("DAL.Entities.Tentaminering", b =>
                {
                    b.HasOne("DAL.Entities.Evl", "Evl")
                        .WithMany("Tentamineringen")
                        .HasForeignKey("EvlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evl");
                });

            modelBuilder.Entity("LeeruitkomstTentaminering", b =>
                {
                    b.HasOne("DAL.Entities.Leeruitkomst", null)
                        .WithMany()
                        .HasForeignKey("LeeruitkomstenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Tentaminering", null)
                        .WithMany()
                        .HasForeignKey("TentamineringenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Beoordelingsdimensie", b =>
                {
                    b.Navigation("Beoordelingscriteria");
                });

            modelBuilder.Entity("DAL.Entities.Evl", b =>
                {
                    b.Navigation("Leeruitkomsten");

                    b.Navigation("Tentamineringen");
                });

            modelBuilder.Entity("DAL.Entities.Tentaminering", b =>
                {
                    b.Navigation("Beoordelingsdimensies");
                });
#pragma warning restore 612, 618
        }
    }
}
