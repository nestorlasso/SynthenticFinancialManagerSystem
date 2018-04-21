using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Data.Extensions;
using SynthenticFinancialManagerSystem.Data.Model.Configurations;
using SynthenticFinancialManagerSystem.Data.Model.Entities;

namespace SynthenticFinancialManagerSystem.Data.Model.Context
{
    public class BaseIdentityDbContext : IdentityDbContext<User, ApplicationRole, int>
    {
        private readonly DbContextOptions _options;

        public BaseIdentityDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<ActionRole> ActionRole { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }

        private void ConfigureLocalModel(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ActionConfiguration());
            modelBuilder.AddConfiguration(new ActionRoleConfiguration());
            modelBuilder.AddConfiguration(new RoleConfiguration());
            modelBuilder.AddConfiguration(new UserConfiguration());
            modelBuilder.AddConfiguration(new UserRoleConfiguracion());

            modelBuilder.AddConfiguration(new TransactionConfiguration());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureLocalModel(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
