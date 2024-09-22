using TodoApp.Application.Models;
using Wolverine;
using Wolverine.Attributes;

namespace TodoApp.Application.Handlers;

[WolverineHandler]
public class GetTodoDetailsQueryHandler
{
    public static async Task<GetTodoDetailsQueryResult> Handle(
        GetTodoDetailsQuery query,
        IMessageContext context,
        //Envelope envelope,
        //DateTimeOffset now,
        CancellationToken cancel)
    {
        var result = new GetTodoDetailsQueryResult
        {
            Result = new(new TodoDetailsDto(
                query.TodoId,
                "My stuff to do", [
                    new TodoItemDetailsDto(1, "Do stuff", false),
                    new TodoItemDetailsDto(2, "Do more stuff", true),
                    new TodoItemDetailsDto(3, "Whatever you want", false),
                ])),
        };

        //await context.RespondToSenderAsync(result);

        return result;
    }
}
