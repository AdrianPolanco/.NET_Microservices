

using MediatR;

namespace BuildingBlocks.CQRS
{
    //out TResponses here disables the possibility for TResponse to be use as a input/parameter type,
    //so it can only be used as return type in this interface
    public interface IQuery<out TResponse>: IRequest<TResponse> where TResponse: notnull
    {
    }
}
