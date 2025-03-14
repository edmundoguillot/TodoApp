namespace TodoApp.Presentation;

public class ConsoleMenu
{
    private readonly List<MenuItem> _menuItems = new();

    private sealed class MenuItem(string description, char key, Action action)
    {
        public string Description { get; } = description;
        public char Key { get;} = key;
        public Action Action { get; } = action;

        // handle the case where the key is not passed
        public MenuItem(string description, Action action) : this(description, description.ToLower()[0], action)
        {
        }
    }
    public void AddItem(string description, char key, Action action)
    {
        _menuItems.Add(new MenuItem(description, key, action));
    }
    
    // handle the case where the key is not passed
    public void AddItem(string description, Action action)
    {
        _menuItems.Add(new MenuItem(description, action));
    }

    public void Show()
    {
        List<string> choices = new List<string>();
        var exitLoop = false;

        while (!exitLoop)
        {
            ConsoleHelper.Print("Select an option:");
            foreach (var item in _menuItems)
            {
                ConsoleHelper.Print($"[{item.Key}] {item.Description}", ConsoleColor.Gray, false);
                choices.Add(item.Key.ToString());
            }

            var choice = ConsoleHelper.GetSelection("Enter your choice: ", choices);
            var userSelection = _menuItems.Find(item => item.Key.ToString() == choice);

            userSelection.Action();

            choice = ConsoleHelper.GetSelection("Would you like to select another item? (y/n):", ["y", "n"]);
            
            if (choice == "n")
                exitLoop = true;
            
            choices.Clear();

        }
    }
}
