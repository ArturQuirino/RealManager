using Microsoft.EntityFrameworkCore;
using RealManager.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<TeamDb> Teams { get; set; }
        public DbSet<PlayerDb> Players { get; set; }

    }
}
