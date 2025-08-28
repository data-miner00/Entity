namespace Entity.Console.Data
{
    using Entity.Common;
    using Entity.Console.Models;
    using Entity.Console.Seeds;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The E-commerce application's database context.
    /// </summary>
    public sealed class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Credential> Credentials { get; set; }

        public DbSet<Shop> Shops { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(Constants.MSSQLConnectionString);
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupDefaultDate<User>();
            SetupDefaultDate<Order>();
            SetupDefaultDate<Product>();
            SetupDefaultDate<OrderDetail>();
            SetupDefaultDate<UserProfile>();
            SetupDefaultDate<Address>();
            SetupDefaultDate<Credential>();
            SetupDefaultDate<Shop>();

            // After added this, need to add a new migration to apply the seeds
            // It won't automatically seed on startup
            modelBuilder.SeedUsers();

            base.OnModelCreating(modelBuilder);

            void SetupDefaultDate<T>()
                where T : ECommerceEntity
            {
                modelBuilder.Entity<T>()
                    .Property(x => x.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity<T>()
                    .Property(x => x.UpdatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
            }
        }
    }
}
