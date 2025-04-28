using MediatR;
using Dev.Domain.Abstraction;

namespace Dev.Application.Abstraction.Messaging.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
        where TResponse : IResult;

}