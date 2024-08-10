using Carter;
using Discount.API.Models;
using MediatR;

namespace Discount.API.Discounts.Delete
{
    public class DeleteDiscountEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/discounts/{productId}", async (Guid productId, ISender sender) =>
            {
                var request = new DeleteDiscountRequest { Id = productId };
                var result = await sender.Send(request);
                if (result is null) return Results.NotFound();
                return Results.Ok(result);
            })
                .Produces<DeleteDiscountResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Discount")
                .WithDescription("Delete Discount");
        }
    }
}
