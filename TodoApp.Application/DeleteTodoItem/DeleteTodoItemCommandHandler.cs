using TodoApp.Application.Persistence;

namespace TodoApp.Application.DeleteTodoItem;

public class DeleteTodoItemCommandHandler(ITodoRepository todoRepository)
{
    public bool Handle(Guid id)
    {
        return todoRepository.Delete(id);
    }
}