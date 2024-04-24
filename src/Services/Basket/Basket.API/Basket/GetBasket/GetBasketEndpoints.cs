

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(username));
                var response = result.Adapt<GetBasketResponse>();
                return Results.Ok(response);
            })
                .WithName("GetBasketByUsername")
                .Produces<GetBasketResponse>()
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Gets basket by username")
                .WithDescription("Gets basket by username");
        }
    }
}
