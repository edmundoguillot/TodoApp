using System.ComponentModel.DataAnnotations;
using TodoApp.Application.Models;

namespace TodoApp.Application.CreateTodoItem;

public class CreateTodoItemCommandHandler
{
    public Guid Handle(CreateTodoItemCommand command)
    {
        if (command.Title is null)
        {
            throw new ValidationException("Title is required");
        }

        if (command.Description is not null && string.IsNullOrWhiteSpace(command.Description))
        {
            throw new ValidationException("Description is required");
        }
        
        var todoItem = new TodoItem(
            Guid.NewGuid(),
            command.Title,
            command.Description,
            command.CompleteBy
        );

        return todoItem.Id;
    }
}