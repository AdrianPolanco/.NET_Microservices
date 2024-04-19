

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(
        string Name, 
        List<string> CategoryList, 
        string Description, 
        string ImageFile, 
        decimal Price): ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.CategoryList).NotEmpty().WithMessage("The product must own to at least one category");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image File is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    //ICommandHandler<C, R> viene del IRequestHandler<C, R>, donde C debe ser una clase o record
    //que implemente ICommand<R>, ICommand<R> viene de IRequest<R>
    //IRequestHandler<C,R> acepta C como entrada y devuelve R como respuesta
    internal class CreateProductCommandHandler(IDocumentSession documentSession)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Removed logging because we added a new LoggingBehavior in order to get rid of logging repetitive code in each handler
            //logger.LogInformation("CreateProductCommandHandler.Handle called with {@Command}", command);
            //Implement business logic to create a product

            Product product = new()
            {
                Name = command.Name,
                CategoryList = command.CategoryList,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //TODO
            //Save to the database
            //Gives to the saved product an Guid
            documentSession.Store(product);
            await documentSession.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
