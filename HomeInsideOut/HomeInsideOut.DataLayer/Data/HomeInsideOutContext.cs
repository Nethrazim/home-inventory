using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HomeInsideOut.DataLayer.Models;
using Microsoft.Extensions.Configuration;

namespace HomeInsideOut.DataLayer.Data
{
    public partial class HomeInsideOutContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public HomeInsideOutContext(IConfiguration configuration, DbContextOptions<HomeInsideOutContext> options)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasIndex(e => e.Name, "UK_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.HashedPassword).HasMaxLength(255);

                entity.Property(e => e.Salt).HasMaxLength(64);

                entity.Property(e => e.Username)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
