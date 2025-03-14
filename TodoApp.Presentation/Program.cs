using TodoApp.Presentation;

ConsoleMenu menu = new ConsoleMenu();
menu.AddItem("List all items", 'l', () => ConsoleHelper.Print("Listing all items"));
menu.AddItem("Create item", () => ConsoleHelper.Print("Creating a new item"));
menu.AddItem("Update item", 'u', () => ConsoleHelper.Print("Updating item"));
menu.AddItem("Delete item", 'd', () => ConsoleHelper.Print("Deleting item"));
menu.AddItem("Exit", 'x', () => Environment.Exit(0));

menu.Show();