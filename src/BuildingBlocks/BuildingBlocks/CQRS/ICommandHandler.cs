using BuildingBlocks.CQRS;
using MediatR;

namespace DefaultNamespace;

public interface ICommandHandler<in TCommand>: ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>;

public interface ICommandHandler<in TCommand,TResponse> 
    : IRequestHandler<TCommand,TResponse> 
    where TCommand : ICommand<TResponse>
    where TResponse: notnull
{
    
}