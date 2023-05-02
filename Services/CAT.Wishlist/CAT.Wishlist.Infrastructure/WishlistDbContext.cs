using Microsoft.EntityFrameworkCore;

namespace CAT.Wishlist.Infrastructure
{
    public class WishlistDbContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "listing";

        public WishlistDbContext(DbContextOptions<WishlistDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.WishlistAggregate.Wishlist> Wishlists { get; set; }

        public DbSet<Domain.WishlistAggregate.WishlistItem> WishlistItems { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.WishlistAggregate.Wishlist>().ToTable("Wishlists", DEFAULT_SCHEMA);

            modelBuilder.Entity<Domain.WishlistAggregate.WishlistItem>().ToTable("WishlistItems", DEFAULT_SCHEMA);

            modelBuilder.Entity<Domain.WishlistAggregate.WishlistItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Domain.WishlistAggregate.Wishlist>().OwnsOne(o => o.Label).WithOwner();

            base.OnModelCreating(modelBuilder);
        }
    }
}
