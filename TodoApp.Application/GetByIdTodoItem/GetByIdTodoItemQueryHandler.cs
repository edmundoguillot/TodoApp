using TodoApp.Application.Models;
using TodoApp.Application.Persistence;

namespace TodoApp.Application.GetByIdTodoItem;

public class GetByIdTodoItemQueryHandler(ITodoRepository repository)
{
    public TodoItem? Handle(Guid id)
    {
        return repository.GetById(id);
    }
}