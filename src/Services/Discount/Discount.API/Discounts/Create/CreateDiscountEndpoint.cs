using Carter;
using Discount.API.Models;
using MediatR;

namespace Discount.API.Discounts.Create
{
    public class CreateDiscountEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/discounts", async(CreateDiscountRequest request, ISender sender) =>
            {
                var result = await sender.Send(request);
                return Results.Created($"/discounts/{result.Id}", result);
            })
                .Produces<CouponModel>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Discount")
                .WithDescription("Create Discount");
        }
    }
}
