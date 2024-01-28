﻿using ErrorHandling.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrorHandling.Database;

public class ErrorHandlingDbContext : DbContext
{
    public ErrorHandlingDbContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ErrorHandlingDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Enumerable.Range(1, 5).ToList().ForEach(index =>
        {
            modelBuilder.Entity<CompanyEntity>().HasData(new CompanyEntity
            {
                Id = index,
                Name = $"Company {index}",
                Description = $"Description of company {index}",
                UserCountMax = Random.Shared.Next(1, 100)
            });
        });

        Enumerable.Range(1, 10).ToList().ForEach(index =>
        {
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = index,
                Name = $"Company {index}",
                Email = $"user_{index}@example.com",
                CompanyId = Random.Shared.Next(1, 6)
            });
        });
        base.OnModelCreating(modelBuilder);
    }
}