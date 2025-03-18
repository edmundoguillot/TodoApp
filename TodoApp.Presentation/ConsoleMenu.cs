namespace TodoApp.Presentation;

public class ConsoleMenu
{
    private readonly List<MenuItem> _menuItems = new();

    // private sealed class MenuItem
    // {
    //     public required string Description { get; init; }
    //          public required char Key { get; init; } 
    //          public required Action Action { get; }
    // }


    private sealed record MenuItem(string Description, Action Action, char Key);
    // {
    //     public string Description { get; } = description;
    //     public char Key { get;} = key;
    //     public Action Action { get; } = action;
    // }
    public void AddItem(string description, Action action, char? key = null)
    {
        key ??= char.ToLower(description[0]);
        _menuItems.Add(new MenuItem(description, action, key.Value));
    }
    
    public void Show()
    {
        var choices = _menuItems.Select(m => m.Key.ToString()).ToList();
        var exitLoop = false;

        while (!exitLoop)
        {
            ConsoleHelper.Print("Select an option:");
            foreach (var item in _menuItems)
            {
                ConsoleHelper.Print($"[{item.Key}] {item.Description}", ConsoleColor.Gray, false);
            }

            var choice = ConsoleHelper.GetSelection("Enter your choice: ", choices);
            var userSelection = _menuItems.Find(item => item.Key.ToString() == choice)!;

            userSelection.Action();

            choice = ConsoleHelper.GetSelection("Would you like to select another item? (y/n):", ["y", "n"]);
            
            if (choice == "n")
                exitLoop = true;
        }
    }
}
