using BuildingBlocks.CQRS;
using Discount.API.Models;
using Discount.API.Services;

namespace Discount.API.Discounts.Get
{
    public class GetDiscountQueryHandler(DiscountService service) : IQueryHandler<GetDiscountRequest, CouponModel>
    {
        public async Task<CouponModel> Handle(GetDiscountRequest request, CancellationToken cancellationToken)
        {
            CouponModel coupon = await service.GetDiscount(request);
            return coupon;
        }
    }
}
