using FluentValidation;
using NetService.Application.Models;
using Wolverine.Attributes;

namespace TodoApp.Application.Models;

[MessageIdentity(nameof(GetTodoDetailsQuery))]
public record GetTodoDetailsQuery(
    string TodoId);

[MessageIdentity(nameof(GetTodoDetailsQueryResult))]
public class GetTodoDetailsQueryResult :
    HandlerResult<GetTodoDetailsQueryResult.Success>
{
    public record Success(TodoDetailsDto Details);
}


public class GetTodoDetailsQueryValidator :
    AbstractValidator<GetTodoDetailsQuery>
{
    public GetTodoDetailsQueryValidator()
    {
        RuleFor(x => x.TodoId).IsValidTodoId();
    }
}
