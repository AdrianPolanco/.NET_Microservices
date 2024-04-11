

using MediatR;

namespace BuildingBlocks.CQRS
{

    public interface ICommandHandler<in TCommand>: IRequestHandler<TCommand, Unit>
        where TCommand: ICommand<Unit> 
    {
    
    }

    //where TCommand: ICommand<TResponse> restriction was done because the TCommand type is required by MediatR to implement
    //or inherit from the IRequestHandler interface, what is fulfilled by ICommand interface
    public interface ICommandHandler<in TCommand, TResponse>: IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse> 
        where TResponse: notnull
    {

    }
}
