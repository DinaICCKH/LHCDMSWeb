using Microsoft.EntityFrameworkCore;

namespace BackOfficeWeb
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // ================================
        // Tables (if you have real tables)
        // ================================
        public DbSet<PO> POs { get; set; }
        public DbSet<PO1> PO1s { get; set; }

        // ================================
        // Stored Procedure Result Models
        // ================================
        public DbSet<Item> Items { get; set; }
        public DbSet<SpResult> SpResults { get; set; }
        public DbSet<LoginResult> LoginResults { get; set; }
        public DbSet<ItemLoginResult> ItemLoginResults { get; set; }
        public DbSet<CustomerResult> CustomerResults { get; set; }
        public DbSet<WhsResult> WhsResults { get; set; }
        public DbSet<UoMResult> UoMResults { get; set; }
        public DbSet<UoMGroupResult> UoMGroupResults { get; set; }
        public DbSet<PriceListResult> PriceListResults { get; set; }
        public DbSet<ItemPricingResult> ItemPricingResults { get; set; }

        // ================================
        // Model Configuration
        // ================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply NoKey to all SP result models
            ApplyNoKey<PO>(modelBuilder);
            ApplyNoKey<PO1>(modelBuilder);

            ApplyNoKey<Item>(modelBuilder);
            ApplyNoKey<SpResult>(modelBuilder);

            ApplyNoKey<LoginResult>(modelBuilder);
            ApplyNoKey<ItemLoginResult>(modelBuilder);
            ApplyNoKey<CustomerResult>(modelBuilder);
            ApplyNoKey<WhsResult>(modelBuilder);
            ApplyNoKey<UoMResult>(modelBuilder);
            ApplyNoKey<UoMGroupResult>(modelBuilder);
            ApplyNoKey<PriceListResult>(modelBuilder);
            ApplyNoKey<ItemPricingResult>(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        // ================================
        // Helper Method (Cleaner)
        // ================================
        private void ApplyNoKey<T>(ModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>().HasNoKey();
        }
    }
}