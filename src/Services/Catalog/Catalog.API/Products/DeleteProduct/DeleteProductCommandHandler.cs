

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id): ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccessful);
    public class DeleteProductValidator: AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator() {
            RuleFor(c => c.Id).NotEmpty().WithMessage("The Id is required for this operation");
        }
    }
    public class DeleteProductCommandHandler(IDocumentSession documentSession)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            documentSession.Delete<Product>(command.Id);
            await documentSession.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
