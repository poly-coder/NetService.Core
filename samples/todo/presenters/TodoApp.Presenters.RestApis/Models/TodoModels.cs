namespace TodoApp.Presenters.RestApis.Models;

public record TodoDetails(
    string Id,
    string Title,
    IEnumerable<TodoItemDetails> Items);

public record TodoItemDetails(
    int Id,
    string Title,
    bool Completed);
