using Carter;
using Discount.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Discounts.Get
{
    public class GetDiscountEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/discounts", async ([FromBody] GetDiscountRequest request, ISender sender) =>
            {
                if(string.IsNullOrEmpty(request.ProductName)) return Results.BadRequest();
                
                var result = await sender.Send(request);
                return result == null ? Results.NotFound() : Results.Ok(result);
            })
                .Produces<CouponModel>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Get Discount By Product Name")
                .WithDescription("Get Discount By Product Name");
        }
    }
}
