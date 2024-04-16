
namespace Catalog.API.Products.GetProduct
{
    public record GetProductsQuery(): IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    public class GetProductsHandler(IDocumentSession documentSession, ILogger<GetProductsHandler> logger) 
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsHandler.Handle called with {@Query}", query);

            var products = await documentSession.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
