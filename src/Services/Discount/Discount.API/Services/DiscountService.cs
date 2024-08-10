using Discount.API.Data;
using Discount.API.Entities;
using Discount.API.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
    {
        public async Task<CouponModel> GetDiscount(GetDiscountRequest request)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

            if (coupon is null) coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Description" };

            logger.LogInformation("Discount is retrieved for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();

            return couponModel;
        }

        public async Task<CouponModel> CreateDiscount(CreateDiscountRequest request)
        {
            Coupon coupon = request.Adapt<Coupon>();
            await dbContext.Coupons.AddAsync(coupon);
            logger.LogInformation("Discount is successfully created. ProductName: {ProductName}", coupon.ProductName);
            await dbContext.SaveChangesAsync();
            return coupon.Adapt<CouponModel>();
        }

        public async Task<CouponModel?> UpdateDiscount(UpdateDiscountRequest request)
        {
            Coupon coupon = request.Adapt<Coupon>();
            coupon = await dbContext.FindAsync<Coupon>(coupon.Id);
            if (coupon is null) return null;
            
            if(coupon.ProductName != request.ProductName && coupon.Amount != request.Amount && coupon.Description != request.Description)
            {
                coupon.ProductName = request.ProductName;
                coupon.Amount = request.Amount;
                coupon.Description = request.Description;
                dbContext.Coupons.Update(coupon);
                await dbContext.SaveChangesAsync();
            }
       
            logger.LogInformation("Discount is successfully updated. ProductName: {ProductName}", coupon.ProductName);
            return coupon.Adapt<CouponModel>(); 
        }

        public async Task<CouponModel?> DeleteDiscount(DeleteDiscountRequest request)
        {
            Coupon coupon = await dbContext.FindAsync<Coupon>(request.Id);
            if (coupon is null) return null;
            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully deleted. ProductName: {ProductName}", coupon.ProductName);
            return coupon.Adapt<CouponModel>();
        }
    }
}
