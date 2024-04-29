﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceInfo.Persistence;

#nullable disable

namespace SpaceInfo.Persistence.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20240420123442_V3")]
    partial class V3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpaceInfo.Domain.CloseApproachData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CloseApproachDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CloseApproachDateFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("EpochDateCloseApproach")
                        .HasColumnType("float");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("NearEarthObjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrbitingBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NearEarthObjectId");

                    b.ToTable("CloseApproachData");
                });

            modelBuilder.Entity("SpaceInfo.Domain.DailyInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Copyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hdurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("MediaType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DailyInfo");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Diameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("NearEarthObjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NearEarthObjectId")
                        .IsUnique()
                        .HasFilter("[NearEarthObjectId] IS NOT NULL");

                    b.ToTable("Diameter");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Feet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DiameterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("EstimatedDiameterMax")
                        .HasColumnType("float");

                    b.Property<double>("EstimatedDiameterMin")
                        .HasColumnType("float");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DiameterId")
                        .IsUnique();

                    b.ToTable("Feet");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Kilometers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DiameterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("EstimatedDiameterMax")
                        .HasColumnType("float");

                    b.Property<double>("EstimatedDiameterMin")
                        .HasColumnType("float");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DiameterId")
                        .IsUnique();

                    b.ToTable("Kilometer");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Links", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("NearEarthObjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Next")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Previous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Self")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NearEarthObjectId")
                        .IsUnique()
                        .HasFilter("[NearEarthObjectId] IS NOT NULL");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Meters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DiameterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("EstimatedDiameterMax")
                        .HasColumnType("float");

                    b.Property<double>("EstimatedDiameterMin")
                        .HasColumnType("float");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DiameterId")
                        .IsUnique();

                    b.ToTable("Meter");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Miles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DiameterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("EstimatedDiameterMax")
                        .HasColumnType("float");

                    b.Property<double>("EstimatedDiameterMin")
                        .HasColumnType("float");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DiameterId")
                        .IsUnique();

                    b.ToTable("Mile");
                });

            modelBuilder.Entity("SpaceInfo.Domain.MissDistance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Astronomical")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CloseApproachDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Kilometers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lunar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CloseApproachDataId")
                        .IsUnique();

                    b.ToTable("MissDistances");
                });

            modelBuilder.Entity("SpaceInfo.Domain.NearEarthObject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AbsoluteMagnitudeH")
                        .HasColumnType("float");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPotentiallyHazardous")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NasaJplUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NeoReferenceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("NearEarthObjects");
                });

            modelBuilder.Entity("SpaceInfo.Domain.RelativeVelocity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CloseApproachDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("KilometersPerHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KilometersPerSecond")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MilesPerHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CloseApproachDataId")
                        .IsUnique();

                    b.ToTable("RelativeVelocity");
                });

            modelBuilder.Entity("SpaceInfo.Domain.CloseApproachData", b =>
                {
                    b.HasOne("SpaceInfo.Domain.NearEarthObject", "NearEarthObject")
                        .WithMany("CloseApproachDatas")
                        .HasForeignKey("NearEarthObjectId");

                    b.Navigation("NearEarthObject");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Diameter", b =>
                {
                    b.HasOne("SpaceInfo.Domain.NearEarthObject", "NearEarthObject")
                        .WithOne("Diameter")
                        .HasForeignKey("SpaceInfo.Domain.Diameter", "NearEarthObjectId");

                    b.Navigation("NearEarthObject");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Feet", b =>
                {
                    b.HasOne("SpaceInfo.Domain.Diameter", "Diameter")
                        .WithOne("Feet")
                        .HasForeignKey("SpaceInfo.Domain.Feet", "DiameterId");

                    b.Navigation("Diameter");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Kilometers", b =>
                {
                    b.HasOne("SpaceInfo.Domain.Diameter", "Diameter")
                        .WithOne("Kilometers")
                        .HasForeignKey("SpaceInfo.Domain.Kilometers", "DiameterId");

                    b.Navigation("Diameter");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Links", b =>
                {
                    b.HasOne("SpaceInfo.Domain.NearEarthObject", "NearEarthObject")
                        .WithOne("Link")
                        .HasForeignKey("SpaceInfo.Domain.Links", "NearEarthObjectId");

                    b.Navigation("NearEarthObject");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Meters", b =>
                {
                    b.HasOne("SpaceInfo.Domain.Diameter", "Diameter")
                        .WithOne("Meters")
                        .HasForeignKey("SpaceInfo.Domain.Meters", "DiameterId");

                    b.Navigation("Diameter");
                });

            modelBuilder.Entity("SpaceInfo.Domain.Miles", b =>
                {
                    b.HasOne("SpaceInfo.Domain.Diameter", "Diameter")
                        .WithOne("Miles")
                        .HasForeignKey("SpaceInfo.Domain.Miles", "DiameterId");

                    b.Navigation("Diameter");
                });

            modelBuilder.Entity("SpaceInfo.Domain.MissDistance", b =>
                {
                    b.HasOne("SpaceInfo.Domain.CloseApproachData", "CloseApproachData")
                        .WithOne("MissDistance")
                        .HasForeignKey("SpaceInfo.Domain.MissDistance", "CloseApproachDataId");

                    b.Navigation("CloseApproachData");
                });

            modelBuilder.Entity("SpaceInfo.Domain.RelativeVelocity", b =>
                {
                    b.HasOne("SpaceInfo.Domain.CloseApproachData", "CloseApproachData")
                        .WithOne("RelativeVelocity")
                        .HasForeignKey("SpaceInfo.Domain.RelativeVelocity", "CloseApproachDataId");

                    b.Navigation("CloseApproachData");
                });

            modelBuilder.Entity("SpaceInfo.Domain.CloseApproachData", b =>
                {
                    b.Navigation("MissDistance")
                        .IsRequired();

                    b.Navigation("RelativeVelocity")
                        .IsRequired();
                });

            modelBuilder.Entity("SpaceInfo.Domain.Diameter", b =>
                {
                    b.Navigation("Feet")
                        .IsRequired();

                    b.Navigation("Kilometers")
                        .IsRequired();

                    b.Navigation("Meters")
                        .IsRequired();

                    b.Navigation("Miles")
                        .IsRequired();
                });

            modelBuilder.Entity("SpaceInfo.Domain.NearEarthObject", b =>
                {
                    b.Navigation("CloseApproachDatas");

                    b.Navigation("Diameter")
                        .IsRequired();

                    b.Navigation("Link")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}