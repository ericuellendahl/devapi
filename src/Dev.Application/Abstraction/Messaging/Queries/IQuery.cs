using Dev.Domain.Abstraction;
using MediatR;

namespace Dev.Application.Abstraction.Messaging.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IResult;

