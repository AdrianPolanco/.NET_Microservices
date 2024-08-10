using BuildingBlocks.CQRS;
using Discount.API.Models;
using Discount.API.Services;

namespace Discount.API.Discounts.Delete
{
    public class DeleteDiscountCommandHandler(DiscountService service) : ICommandHandler<DeleteDiscountRequest, DeleteDiscountResponse>
    {
        public async Task<DeleteDiscountResponse> Handle(DeleteDiscountRequest request, CancellationToken cancellationToken)
        {
            CouponModel coupon = await service.DeleteDiscount(request);
            bool succeed = coupon != null;
            return new DeleteDiscountResponse { Success = succeed};
        }
    }
}
