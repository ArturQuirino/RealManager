using Microsoft.EntityFrameworkCore;
using RealManager.Repositories.Models;

namespace RealManager.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<TeamDb> Teams { get; set; }
        public DbSet<PlayerDb> Players { get; set; }
        public DbSet<MatchDb> Matches { get; set; }
        public DbSet<MatchEventDb> MatchEvents { get; set; }
        public DbSet<MatchEventDescriptionDb> MatchEventDescriptions { get; set; }
        public DbSet<LeagueDb> Leagues { get; set; }

    }
}
