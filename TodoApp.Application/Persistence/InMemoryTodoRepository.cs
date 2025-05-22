using TodoApp.Application.Models;

namespace TodoApp.Application.Persistence;

public class InMemoryTodoRepository: ITodoRepository
{
    private readonly Dictionary<Guid, TodoItem> _items = [];
    
    public void Save(TodoItem item)
    {
       _items[item.Id] = item;
       // _items.Add(item.Id, item);
    }

    public TodoItem? GetById(Guid id) => _items.GetValueOrDefault(id);

    public List<TodoItem> GetAll() => _items.Values.ToList();

    public bool Delete(Guid id)
    {
        var result = false;
        if (_items.ContainsKey(id))
        {
            _items.Remove(id);
            result = true;
        }
        return result;
    }
}