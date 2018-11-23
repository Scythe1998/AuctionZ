﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class AuctionContext : DbContext //UOF
    {
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
            DbInitializer.Seed(this);
        }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>(ConfigureBids);
            modelBuilder.Entity<Lot>(ConfigureLot);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Category>(ConfigureCategory);
        }

        private void ConfigureBids(EntityTypeBuilder<Bid> builder)
        {
            builder
                .Property(x => x.Price)
                .HasColumnType("decimal(18,2)");
        }

        private void ConfigureLot(EntityTypeBuilder<Lot> builder)
        {
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Lots)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(x => x.Price)
                .HasColumnType("decimal(18,2)");
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(x => x.Bids)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(x => x.Money)
                .HasColumnType("decimal(18,2)");

        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(x => x.Lots)
                .WithOne(x => x.Category)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
