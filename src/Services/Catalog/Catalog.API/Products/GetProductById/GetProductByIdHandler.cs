

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductsHandler(IDocumentSession documentSession, ILogger<GetProductsHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsHandler.Handle called with {@Query}", query);

            var product = await documentSession.LoadAsync<Product>(query.Id, cancellationToken);
            if (product is null) throw new ProductNotFoundException(query.Id);

            return new GetProductByIdResult(product);
        }
    }
}
