using System.Text.Json;
using TodoApp.Application.Models;

namespace TodoApp.Application.Persistence;

public class OnDiskTodoRepository : ITodoRepository
{
    private readonly Dictionary<Guid, TodoItem> _items = [];
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
    private readonly string _path = GetFilePath();

    public OnDiskTodoRepository()
    {
        LoadTodos();
    }
    
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
    
    private void LoadTodos()
    {
        if (!File.Exists(_path)) return;
        
        var json = File.ReadAllText(_path);
        var items = JsonSerializer.Deserialize<List<TodoItem>>(json);
        if (items is null) return;
        
        foreach (var item in items)
        {
            _items[item.Id] = item;
        }
    }

    private void SaveTodos()
    {
        var directory = Path.GetDirectoryName(_path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        var json = JsonSerializer.Serialize(_items.Values.ToList(), _options);
        File.WriteAllText(_path, json);
    }
    
    private static string GetFilePath()
        {
            var baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dataDirectory = Path.Combine(baseDirectory, "TodoApp");
            var fileName = "todos.json";
            return Path.Combine(dataDirectory, fileName);
        }
}