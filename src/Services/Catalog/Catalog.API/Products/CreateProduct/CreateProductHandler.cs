﻿using MediatR;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, 
        List<string> CategoryList, 
        string Description, 
        string ImageFile, 
        decimal Price): IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Implement business logic to create a product
            throw new NotImplementedException();
        }
    }
}
