using BuildingBlocks.CQRS;

namespace Discount.API.Models
{
    public class GetDiscountRequest : IQuery<CouponModel>
    {
        public string ProductName { get; set; }
    }

    public class CouponModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }

    public class CreateDiscountRequest: ICommand<CouponModel>
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }

    public class UpdateDiscountRequest : ICommand<CouponModel>
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }

    public class DeleteDiscountRequest : ICommand<DeleteDiscountResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeleteDiscountResponse
    {
        public bool Success { get; set; }
    }
}
