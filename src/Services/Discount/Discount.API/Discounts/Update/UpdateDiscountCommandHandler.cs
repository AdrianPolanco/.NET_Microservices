using BuildingBlocks.CQRS;
using Discount.API.Models;
using Discount.API.Services;
using FluentValidation;

namespace Discount.API.Discounts.Update
{
    public class UpdateDiscountRequestValidator : AbstractValidator<UpdateDiscountRequest>
    {
        public UpdateDiscountRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
    public class UpdateDiscountCommandHandler(DiscountService service) : ICommandHandler<UpdateDiscountRequest, CouponModel>
    {
        public async Task<CouponModel?> Handle(UpdateDiscountRequest request, CancellationToken cancellationToken)
        {
            CouponModel coupon = await service.UpdateDiscount(request);
            return coupon;
        }
    }
}
