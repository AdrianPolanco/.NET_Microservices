
namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductByCategoryQuery(string Category): IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    public class GetProductByCategoryHandler(IDocumentSession documentSession, ILogger<GetProductByCategoryHandler> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsHandler.Handle called with {@Query}", query);
            var products = await documentSession.Query<Product>().Where(p => p.CategoryList.Contains(query.Category)).ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }
}
