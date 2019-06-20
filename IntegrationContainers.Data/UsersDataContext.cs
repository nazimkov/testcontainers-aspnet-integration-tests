using IntegrationContainers.Data.Configurations;
using IntegrationContainers.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegrationContainers.Data
{
    public class UsersDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        private readonly IContextConfiguration _config;

        public UsersDataContext(IContextConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserTeamConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}