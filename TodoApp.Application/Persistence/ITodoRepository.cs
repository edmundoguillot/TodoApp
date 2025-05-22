using TodoApp.Application.Models;

namespace TodoApp.Application.Persistence;

public interface ITodoRepository
{
    void Save(TodoItem item);
    TodoItem? GetById(Guid id);
    List<TodoItem> GetAll();
    bool Delete(Guid id);
}