﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vehicles.Database;

#nullable disable

namespace Vehicles.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240918071324_Manufacturer_Model")]
    partial class Manufacturer_Model
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vehicles.Database.Entities.ColorEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Code")
                        .IsUnique();

                    b.ToTable("Color");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "ffffff",
                            Name = "white"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "000000",
                            Name = "black"
                        });
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ManufacturerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("IntrouctionYear")
                        .HasColumnType("bigint");

                    b.Property<long>("ManufacturerId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ModelName")
                        .IsUnique();

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ChassisNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<long>("ColorId")
                        .HasColumnType("bigint");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<long>("ModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("NumberOfDoors")
                        .HasColumnType("bigint");

                    b.Property<long>("Power")
                        .HasColumnType("bigint");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("LicencePlate")
                        .IsUnique();

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.ColorEntity", "Color")
                        .WithMany("Vehicles")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.ModelEntity", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ColorEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
