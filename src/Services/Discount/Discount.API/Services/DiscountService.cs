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

       /* public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request)
        {
            return base.CreateDiscount(request, context);
        }

        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            return base.UpdateDiscount(request, context);
        }

        public override Task<CouponModel> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            return base.DeleteDiscount(request, context);
        }*/
    }
}
