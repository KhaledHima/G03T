using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Stock Seeded in sql

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "mahmoud",
                    Email = "mahmoud@example.com",
                    PasswordHash = "REPLACE_WITH_HASHED_PASSWORD_1"
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "ahmed",
                    Email = "ahmed@example.com",
                    PasswordHash = "REPLACE_WITH_HASHED_PASSWORD_2"
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "mona",
                    Email = "mona@example.com",
                    PasswordHash = "REPLACE_WITH_HASHED_PASSWORD_3"
                }
            );

            modelBuilder.Entity<Wallet>().HasData(
                new Wallet
                {
                    Id = 1,
                    AppUserId = 1,
                    StockId = 1,
                    Quantity = 10
                },
                new Wallet
                {
                    Id = 2,
                    AppUserId = 2,
                    StockId = 2,
                    Quantity = 20
                },
                new Wallet
                {
                    Id = 3,
                    AppUserId = 3,
                    StockId = 3,
                    Quantity = 30
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Title = "Apple Stock",
                    Content = "Apple is a technology company.",
                    CreatedAt = new DateTime(2026, 1, 1),
                    StockId = 1
                },
                new Comment
                {
                    Id = 2,
                    Title = "Microsoft Stock",
                    Content = "Microsoft provides cloud and software services.",
                    CreatedAt = new DateTime(2026, 1, 2),
                    StockId = 2
                },
                new Comment
                {
                    Id = 3,
                    Title = "Google Stock",
                    Content = "Alphabet is the parent company of Google.",
                    CreatedAt = new DateTime(2026, 1, 3),
                    StockId = 3
                }
            );
        }
    }
}
