namespace TodoApp.Application.Models;

public record TodoDetailsDto(
    string Id,
    string Title,
    IEnumerable<TodoItemDetailsDto> Items);

public record TodoItemDetailsDto(
    int Id,
    string Title,
    bool Completed);
