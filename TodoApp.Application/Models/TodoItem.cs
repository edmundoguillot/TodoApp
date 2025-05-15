namespace TodoApp.Application.Models;

public record TodoItem(
    Guid Id,
    string Title,
    string? Description,
    DateTime? CompleteBy);