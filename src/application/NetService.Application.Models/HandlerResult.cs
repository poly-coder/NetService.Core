namespace NetService.Application.Models;


public abstract class HandlerResult<TResult>
    where TResult : class
{
    public TResult? Result { get; init; }
    public ValidationProblemDetailsDto? BadRequest { get; init; }
    public ProblemDetailsDto? Unauthorized { get; init; }
    public ProblemDetailsDto? NotFound { get; init; }
    public ProblemDetailsDto? Conflict { get; init; }
    public ProblemDetailsDto? ServerFailure { get; init; }
}
