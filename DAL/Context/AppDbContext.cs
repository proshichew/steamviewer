using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=mysecretpassword");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(e =>
            {
                e.HasKey(n => n.Id);
                e.Property(n => n.SteamID).IsRequired();
            });

            modelBuilder.Entity<Wishlist>(e =>
            {
                e.HasMany(w => w.Games)
                .WithMany(g => g.Wishlists)
                .UsingEntity(j => j.ToTable("WishlistGames"));

            });
        }
    }
}
