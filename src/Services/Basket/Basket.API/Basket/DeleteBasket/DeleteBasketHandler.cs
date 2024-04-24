
namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string Username): ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    public class DeleteBasketValidator: AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
        }
    }
    public class DeleteBasketHandler(IBasketRepository basketRepository) 
        : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            await basketRepository.DeleteBasket(request.Username, cancellationToken);
            //TODO: Delete basket from database and cache
            return new DeleteBasketResult(true);
        }
    }
}
