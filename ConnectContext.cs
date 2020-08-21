using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GraphCocoApp
{
    public class ConnectContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public ConnectContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public  DbSet<ConnectUser> ConnectUsers { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=uni.db");
            options.UseLoggerFactory(_loggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectUser>()
                .HasMany(t => t.Customers);
            modelBuilder.Entity<Access>()
                .HasMany(t => t.Roles);

            modelBuilder.Entity<Role>()
                .HasIndex(t => new {t.RoleId,t.CustomerID});

            modelBuilder.Entity<Customer>();
        }
    }
}
