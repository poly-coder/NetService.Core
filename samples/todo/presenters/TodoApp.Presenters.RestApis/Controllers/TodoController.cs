using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetService.Presenters.RestApis;
using Swashbuckle.AspNetCore.Annotations;
using TodoApp.Application.Models;
using TodoApp.Presenters.RestApis.Models;
using Wolverine;

namespace TodoApp.Presenters.RestApis.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    /// <summary>
    /// Get todo details
    /// </summary>
    [HttpGet("{TodoId}", Name = nameof(GetTodoDetails))]
    [SwaggerResponse(200, "Returns details", typeof(GetTodoDetailsResponseBody))]
    [SwaggerResponse(400, "Bad request", typeof(ValidationProblemDetails))]
    [SwaggerResponse(401, "Unauthorized", typeof(ProblemDetails))]
    [SwaggerResponse(404, "Not found", typeof(ProblemDetails))]
    [SwaggerResponse(409, "Conflict", typeof(ProblemDetails))]
    [SwaggerResponse(500, "Server failure", typeof(ProblemDetails))]
    public async Task<IActionResult> GetTodoDetails(
        [FromRoute] GetTodoDetailsRequestRoute route,
        //[FromRoute] string id,
        [FromServices] IMessageBus bus,
        [FromServices] ILogger<TodoController> logger,
        CancellationToken cancel)
    {
        try
        {
            var message = route.MapToGetTodoDetailsQuery();

            var result = await bus
                .InvokeAsync<GetTodoDetailsQueryResult>(message, cancel);

            return result
                .MapToActionResult(TodoAppMapper.MapToGetTodoDetailsResponseBody);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Failed to get todo details");

            return new StatusCodeResult(500);
        }
    }
}
