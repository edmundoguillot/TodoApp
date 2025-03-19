using TodoApp.Presentation;

var wantsNewsletter = InputHandling.GetBool("Would you like to subscribe to the newsletter? (y/n)");
Console.WriteLine($"Subscription status: {wantsNewsletter}");

ConsoleMenu menu = new ConsoleMenu();
menu.AddItem("List all items", () => ConsoleHelper.Print("Listing all items"));
menu.AddItem("Create item", () => ConsoleHelper.Print("Creating a new item"));
menu.AddItem("Update item", () => ConsoleHelper.Print("Updating item"), 'u');
menu.AddItem("Delete item", () => ConsoleHelper.Print("Deleting item"), 'd');
menu.AddItem("Exit", () => Environment.Exit(0), 'x');

menu.Show();
