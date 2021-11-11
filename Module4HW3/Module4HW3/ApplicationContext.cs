using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Configurations;
using Module4HW3.Entities;

namespace Module4HW3
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringProvider = new ConnectionStringProvider();
            var connectionString = connectionStringProvider.Init().ConnectionString;
            optionsBuilder.UseSqlServer($"Server={connectionString.Server};Database={connectionString.Database};Trusted_Connection={connectionString.Trusted_Connection};");
        }
    }
}
