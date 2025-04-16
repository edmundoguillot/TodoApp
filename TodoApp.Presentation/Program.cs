using TodoApp.Presentation;

var age = InputHandling.GetInput<int>("Enter your age:");
var wantsNewsletter = InputHandling.GetInput<bool>("Subscribe to the newsletter? (true/false):");
var date = InputHandling.GetInput<DateTime>("Enter a date:");


Console.WriteLine($"Age: {age}, Subscribed: {wantsNewsletter}");

ConsoleMenu menu = new ConsoleMenu();
menu.AddItem("List all items", () => ConsoleHelper.Print("Listing all items"));
menu.AddItem("Create item", () => ConsoleHelper.Print("Creating a new item"));
menu.AddItem("Update item", () => ConsoleHelper.Print("Updating item"), 'u');
menu.AddItem("Delete item", () => ConsoleHelper.Print("Deleting item"), 'd');
menu.AddItem("Exit", () => Environment.Exit(0), 'x');

menu.Show();
