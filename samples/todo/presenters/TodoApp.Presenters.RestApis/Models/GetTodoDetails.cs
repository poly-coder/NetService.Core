namespace TodoApp.Presenters.RestApis.Models;

public record GetTodoDetailsRequestRoute(
    string TodoId);

public record GetTodoDetailsResponseBody(
    TodoDetails Details);
