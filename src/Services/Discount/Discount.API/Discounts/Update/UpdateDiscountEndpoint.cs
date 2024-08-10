using Carter;
using Discount.API.Models;
using MediatR;

namespace Discount.API.Discounts.Update
{
    public class UpdateDiscountEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/discounts", async(UpdateDiscountRequest request, ISender sender) =>
            {
                var result = await sender.Send(request);
                if(result is null) return Results.NotFound();
                return Results.Ok(result);
            })
                .Produces<CouponModel>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Update Discount")
                .WithDescription("Update Discount");
        }
    }
}
