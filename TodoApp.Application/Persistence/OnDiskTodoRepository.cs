using System.Text.Json;
using TodoApp.Application.Models;

namespace TodoApp.Application.Persistence;

public class OnDiskTodoRepository : ITodoRepository
{
    private readonly Dictionary<Guid, TodoItem> _items = [];
    
    public void Save(TodoItem item)
    {
        _items[item.Id] = item;
        SaveTodos();
    }

    public TodoItem? GetById(Guid id) => _items.GetValueOrDefault(id);

    public List<TodoItem> GetAll() => _items.Values.ToList();

    public bool Delete(Guid id)
    {
        var removed = _items.Remove(id);
        if (removed)
        {
            SaveTodos();
        }
        return removed;
    }
    
    public void LoadTodos()
    {
        var path = GetFilePath();

        if (!File.Exists(path)) return;
        
        var json = File.ReadAllText(path);
        var items = JsonSerializer.Deserialize<List<TodoItem>>(json);
        if (items is null) return;
        
        foreach (var item in items)
        {
            _items[item.Id] = item;
        }
    }

    private void SaveTodos()
    {
        var path = GetFilePath();
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        var json = JsonSerializer.Serialize(_items.Values.ToList(), new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
    
    private static string GetFilePath()
        {
            var baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dataDirectory = Path.Combine(baseDirectory, "TodoApp");
            var fileName = "todos.json";
            Console.WriteLine(dataDirectory);
            return Path.Combine(dataDirectory, fileName);
        }
}