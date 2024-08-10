using Discount.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>()
                .HasData(
                    new Coupon
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "iPhone X",
                        Description = "iPhoneX Discount",
                        Amount = 50
                    },
                    new Coupon
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "Samsung Galaxy S24",
                        Description = "Samsung Galaxy S24 Discount",
                        Amount = 10
                    },
                    new Coupon
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "Nintendo Switch",
                        Description = "Nintendo Switch Discount",
                        Amount = 20
                    },
                    new Coupon
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "Asus TUF A15",
                        Description = "Asus TUF A15 Discount",
                        Amount = 50
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
