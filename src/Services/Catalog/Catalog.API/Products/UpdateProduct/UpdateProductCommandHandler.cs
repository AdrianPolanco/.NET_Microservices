

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        List<string> CategoryList,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccessful);

    public class UpdateProductValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator() {
            RuleFor(c => c.Id).NotEmpty().WithMessage("The Id is required");
            RuleFor(c => c.Name).NotEmpty().Length(2, 150).WithMessage("Name must have from 2 to 150 characters");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
    internal class UpdateProductCommandHandler(IDocumentSession documentSession)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await documentSession.LoadAsync<Product>(command.Id, cancellationToken);

            if (product is null) throw new ProductNotFoundException(command.Id);

            product.Name = command.Name;
            product.CategoryList = command.CategoryList;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            documentSession.Update(product);
            await documentSession.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
            
        }
    }
}
