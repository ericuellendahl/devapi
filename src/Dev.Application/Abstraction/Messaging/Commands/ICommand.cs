using Dev.Domain.Abstraction;
using MediatR;

namespace Dev.Application.Abstraction.Messaging.Commands;

public interface ICommand : IRequest<Result<NoContentDto>>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
 where TResponse : IResult;

public interface IBaseCommand;
