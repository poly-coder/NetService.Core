using Riok.Mapperly.Abstractions;
using System.Diagnostics.CodeAnalysis;
using TodoApp.Application.Models;

namespace TodoApp.Presenters.RestApis.Models;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Both)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
internal static partial class TodoAppMapper
{
    public static partial GetTodoDetailsQuery MapToGetTodoDetailsQuery(
        this GetTodoDetailsRequestRoute route);

    public static partial GetTodoDetailsResponseBody MapToGetTodoDetailsResponseBody(
        this GetTodoDetailsQueryResult.Success success);

    public static partial TodoDetails MapToTodoDetails(
        this TodoDetailsDto source);

    public static partial TodoItemDetails MapToTodoItemDetails(
        this TodoItemDetailsDto source);
}
