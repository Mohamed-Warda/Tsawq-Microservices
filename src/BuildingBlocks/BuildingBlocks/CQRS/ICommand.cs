using MediatR;

namespace BuildingBlocks.CQRS;


// overload that returns no value
// 'Unit' is basically the void type for mediator
public interface ICommand:ICommand<Unit>
{
}


public interface ICommand<out TResponse>:IRequest<TResponse>
{
    
}