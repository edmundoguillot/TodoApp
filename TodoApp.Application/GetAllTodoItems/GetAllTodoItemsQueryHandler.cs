using TodoApp.Application.Models;
using TodoApp.Application.Persistence;

namespace TodoApp.Application.GetAllTodoItems;

public class GetAllTodoItemsQueryHandler(ITodoRepository todoRepository)
{
    public List<TodoItem> Handle() => todoRepository.GetAll();
}