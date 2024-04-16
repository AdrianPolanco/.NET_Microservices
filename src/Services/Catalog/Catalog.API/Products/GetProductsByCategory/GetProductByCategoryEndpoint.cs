﻿
namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var results = await sender.Send(new GetProductByCategoryQuery(category));
                var response = results.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            })
                .WithName("Get Products by Category")
                .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get products by category")
                .WithDescription("Get products by category");
        }
    }
}
