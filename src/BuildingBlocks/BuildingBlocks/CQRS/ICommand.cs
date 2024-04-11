
using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand<out TResponse>: IRequest<TResponse>
    {
    }

    //Unit is the void return type from MediatR, ICommand<Unit> is an ICommand that does not return any response
    public interface ICommand: ICommand<Unit>
    {

    }
}
