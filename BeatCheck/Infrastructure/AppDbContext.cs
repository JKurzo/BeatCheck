using Infrastructure.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HealthCheckSuiteEntity> HealthCheckSuites { get; set; } = null!;
        public DbSet<HealthCheckDefinitionEntity> HealthCheckDefinitions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthCheckSuiteEntity>()
                .HasMany(h => h.Checks)
                .WithOne(h => h.HealthCheckSuite)
                .HasForeignKey(h => h.HealthCheckSuiteId);
        }
    }
}
