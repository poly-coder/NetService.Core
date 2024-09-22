using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using NetService.Application.Models;
using Riok.Mapperly.Abstractions;

namespace NetService.Presenters.RestApis;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Both)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static partial class RestApisMapper
{
    public static IActionResult MapToActionResult<TInput, TOutput>(
        this HandlerResult<TInput> input,
        Func<TInput, TOutput> mapper)
        where TInput : class
        where TOutput : class
    {
        return input switch
        {
            { Result: { } result } =>
                new OkObjectResult(mapper(result)),
            { BadRequest: { } badRequest } =>
                new BadRequestObjectResult(badRequest.MapToValidationProblemDetails()),
            { Unauthorized: { } unauthorized } =>
                new UnauthorizedObjectResult(unauthorized.MapToProblemDetails()),
            { NotFound: { } notFound } =>
                new NotFoundObjectResult(notFound.MapToProblemDetails()),
            { Conflict: { } conflict } =>
                new ConflictObjectResult(conflict.MapToProblemDetails()),
            { ServerFailure: { } serverFailure } =>
                new ObjectResult(serverFailure) { StatusCode = 500 },
            _ =>
                new StatusCodeResult(500)
        };
    }

    internal static partial ValidationProblemDetails MapToValidationProblemDetails(
        this ValidationProblemDetailsDto dto);

    internal static partial ProblemDetails MapToProblemDetails(
        this ProblemDetailsDto dto);

    internal static IDictionary<string, object?> MapToDictionaryOfStringAndObject(
        Dictionary<string, object?> source)
    {
        return new Dictionary<string, object?>(source);
    }
}
