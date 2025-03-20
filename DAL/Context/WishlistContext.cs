using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class WishlistContext : DbContext
    {
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5431;Username=postgres;Password=mysecretpassword;Database=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wishlist>(e =>
            {
                e.HasMany(w => w.Games)
                .WithMany(g => g.Wishlists)
                .UsingEntity(j => j.ToTable("WishlistGames"));
            });
        }
    }
}
