namespace TodoApp.Application.CreateTodoItem;

public record CreateTodoItemCommand(
    string Title,
    string? Description,
    DateTime? CompleteBy);
    