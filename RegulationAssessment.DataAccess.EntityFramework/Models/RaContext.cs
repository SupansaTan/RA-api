using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RegulationAssessment.Common;

#nullable disable

namespace RegulationAssessment.DataAccess.EntityFramework.Models
{
    public partial class RAContext : DbContext
    {
        public RAContext()
        {
        }

        public RAContext(DbContextOptions<RAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<BusinessLine> BusinessLines { get; set; } = null!;
        public virtual DbSet<CommiteeGroup> CommiteeGroups { get; set; } = null!;
        public virtual DbSet<Duty> Duties { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<ImplementUnit> ImplementUnits { get; set; } = null!;
        public virtual DbSet<KeyAction> KeyActions { get; set; } = null!;
        public virtual DbSet<Law> Laws { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Logging> Loggings { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<RelatedBusiness> RelatedBusinesses { get; set; } = null!;
        public virtual DbSet<RelatedSystem> RelatedSystems { get; set; } = null!;
        public virtual DbSet<Responsibility> Responsibilities { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<System> Systems { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=teletubbies-test.ca8d4ygqo7d5.us-west-2.rds.amazonaws.com;Database=RA;Username=postgres;Password=hgxBGnzgF85n6y2J3J");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<BusinessLine>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CommiteeGroup)
                    .WithMany(p => p.BusinessLines)
                    .HasForeignKey(d => d.CommiteeGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("businessline_fk");
            });

            modelBuilder.Entity<CommiteeGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdvanceNotify).HasDefaultValueSql("3");

                entity.Property(e => e.DarkTheme).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<ImplementUnit>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.BusinessLine)
                    .WithMany(p => p.ImplementUnits)
                    .HasForeignKey(d => d.BusinessLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("implementunit_fk");
            });

            modelBuilder.Entity<KeyAction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Law)
                    .WithMany(p => p.KeyActions)
                    .HasForeignKey(d => d.LawId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("keyaction_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.KeyActions)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("keyaction_fk_1");
            });

            modelBuilder.Entity<Law>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("location_fk_1");

                entity.HasOne(d => d.ImplementUnit)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.ImplementUnitId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("location_fk");
            });

            modelBuilder.Entity<Logging>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Loggings)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("logging_fk_2");

                entity.HasOne(d => d.KeyAct)
                    .WithMany(p => p.Loggings)
                    .HasForeignKey(d => d.KeyActId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("logging_fk_1");

                entity.HasOne(d => d.KeyActNavigation)
                    .WithMany(p => p.Loggings)
                    .HasForeignKey(d => d.KeyActId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("logging_fk_3");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Loggings)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("logging_fk");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("notification_fk_1");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("notification_fk");
            });

            modelBuilder.Entity<RelatedBusiness>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.RelatedBusinesses)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("relatedbusiness_fk_1");

                entity.HasOne(d => d.Law)
                    .WithMany(p => p.RelatedBusinesses)
                    .HasForeignKey(d => d.LawId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("relatedbusiness_fk");
            });

            modelBuilder.Entity<RelatedSystem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Law)
                    .WithMany(p => p.RelatedSystems)
                    .HasForeignKey(d => d.LawId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("relatedsystem_fk");

                entity.HasOne(d => d.System)
                    .WithMany(p => p.RelatedSystems)
                    .HasForeignKey(d => d.SystemId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("relatedsystem_fk_1");
            });

            modelBuilder.Entity<Responsibility>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.KeyAct)
                    .WithMany(p => p.Responsibilities)
                    .HasForeignKey(d => d.KeyActId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("responsibility_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<System>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("task_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
