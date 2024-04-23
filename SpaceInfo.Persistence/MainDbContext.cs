using Microsoft.EntityFrameworkCore;
using SpaceInfo.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace SpaceInfo.Persistence
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
        {
        }

        DbSet<Domain.DailyInfo> DailyInfo { get; set; }
        DbSet<Domain.CloseApproachData> CloseApproachData { get; set; }
        DbSet<Domain.Diameter> Diameter { get; set; }
        DbSet<Domain.Feet> Feet { get; set; }
        DbSet<Domain.Meters> Meter { get; set; }
        DbSet<Domain.Kilometers> Kilometer { get; set; }
        DbSet<Domain.Miles> Mile { get; set; }
        DbSet<Domain.RelativeVelocity> RelativeVelocity { get; set; }
        DbSet<Domain.MissDistance> MissDistances { get; set; }
        DbSet<Domain.NearEarthObject> NearEarthObjects { get; set; }
        DbSet<Domain.Links> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Prop
            modelBuilder.Entity<DailyInfo>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Links>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<MissDistance>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Feet>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<RelativeVelocity>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Kilometers>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Diameter>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<NearEarthObject>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Meters>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Miles>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<CloseApproachData>().Property(p => p.IsDeleted).HasDefaultValue(false);
            #endregion
            #region relition
            modelBuilder.Entity<NearEarthObject>()
                                          .HasOne(e => e.Link)
                                          .WithOne(e => e.NearEarthObject)
                                          .HasForeignKey<Links>(e => e.NearEarthObjectId)
                                          .IsRequired(false);
            modelBuilder.Entity<NearEarthObject>()
                                          .HasOne(e => e.Diameter)
                                          .WithOne(e => e.NearEarthObject)
                                          .HasForeignKey<Diameter>(e => e.NearEarthObjectId)
                                          .IsRequired(false);
            modelBuilder.Entity<CloseApproachData>()
                                         .HasOne(e => e.NearEarthObject)
                                         .WithMany(e => e.CloseApproachDatas)
                                         .HasForeignKey(e => e.NearEarthObjectId)
                                         .IsRequired(false);
            modelBuilder.Entity<Diameter>()
                                          .HasOne(e => e.Kilometers)
                                          .WithOne(e => e.Diameter)
                                          .HasForeignKey<Kilometers>(e => e.DiameterId)
                                          .IsRequired(false);
            modelBuilder.Entity<Diameter>()
                                        .HasOne(e => e.Miles)
                                        .WithOne(e => e.Diameter)
                                        .HasForeignKey<Miles>(e => e.DiameterId)
                                        .IsRequired(false);
            modelBuilder.Entity<Diameter>()
                                          .HasOne(e => e.Feet)
                                          .WithOne(e => e.Diameter)
                                          .HasForeignKey<Feet>(e => e.DiameterId)
                                          .IsRequired(false);
            modelBuilder.Entity<Diameter>()
                                          .HasOne(e => e.Meters)
                                          .WithOne(e => e.Diameter)
                                          .HasForeignKey<Meters>(e => e.DiameterId)
                                          .IsRequired(false);
            modelBuilder.Entity<CloseApproachData>()
                                         .HasOne(e => e.RelativeVelocity)
                                         .WithOne(e => e.CloseApproachData)
                                         .HasForeignKey<RelativeVelocity>(e => e.CloseApproachDataId)
                                         .IsRequired(false);
            modelBuilder.Entity<CloseApproachData>()
                                          .HasOne(e => e.MissDistance)
                                          .WithOne(e => e.CloseApproachData)
                                          .HasForeignKey<MissDistance>(e => e.CloseApproachDataId)
                                          .IsRequired(false);
            #endregion

        }
    }
}
