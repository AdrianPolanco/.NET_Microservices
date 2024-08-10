using BuildingBlocks.CQRS;
using Discount.API.Models;
using Discount.API.Services;
using FluentValidation;

namespace Discount.API.Discounts.Create
{
    public class CreateDiscountRequestValidator : AbstractValidator<CreateDiscountRequest>
    {
        public CreateDiscountRequestValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
    public class CreateDiscountCommandHandler(DiscountService service) : ICommandHandler<CreateDiscountRequest, CouponModel>
    {
        public async Task<CouponModel> Handle(CreateDiscountRequest request, CancellationToken cancellationToken)
        {
            CouponModel coupon = await service.CreateDiscount(request);
            return coupon;
        }
    }
}
