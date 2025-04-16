using TodoApp.Presentation;

string? ValidateAge(int age) =>
    age is >= 18 and <= 120 ? null : "Age must be between 18 and 120.";

int age = InputHandling.GetInput<int>("Enter your age:", ValidateAge);
Console.WriteLine($"Your age: {age}");


ConsoleMenu menu = new ConsoleMenu();
menu.AddItem("List all items", () => ConsoleHelper.Print("Listing all items"));
menu.AddItem("Create item", () => ConsoleHelper.Print("Creating a new item"));
menu.AddItem("Update item", () => ConsoleHelper.Print("Updating item"), 'u');
menu.AddItem("Delete item", () => ConsoleHelper.Print("Deleting item"), 'd');
menu.AddItem("Exit", () => Environment.Exit(0), 'x');

menu.Show();
