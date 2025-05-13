using TodoApp.Application.CreateTodoItem;
using TodoApp.Presentation;

int age = InputHandling.GetInput<int>("Enter your age:");

string title = InputHandling.GetInput<string>("Enter the task title:");
string? description = InputHandling.GetInput<string?>("Enter the task description (optional):");
DateTime? completeBy = InputHandling.GetInput<DateTime?>("Enter a completion date (optional):");


var command = new CreateTodoItemCommand(title, description, completeBy);
var handler = new CreateTodoItemCommandHandler();

try
{
    var id = handler.Handle(command);
    ConsoleHelper.Print($"Todo item Id: {id.ToString()}", ConsoleColor.Blue);
}
catch (Exception e)
{
    ConsoleHelper.Print(e.ToString(), ConsoleColor.Red);
    throw;
}

// if (completeBy is null)
//     Console.WriteLine("No date selected");
// else
//     Console.WriteLine($"Task must be completed by: {completeBy.Value.ToShortDateString()}");

//
// string? ValidateAge(int age) =>
//     age is >= 18 and <= 120 ? null : "Age must be between 18 and 120.";
//
// int age = InputHandling.GetInput<int>("Enter your age:");
// Console.WriteLine($"Your age: {age}");
//
//
// ConsoleMenu menu = new ConsoleMenu();
// menu.AddItem("List all items", () => ConsoleHelper.Print("Listing all items"));
// menu.AddItem("Create item", () => ConsoleHelper.Print("Creating a new item"));
// menu.AddItem("Update item", () => ConsoleHelper.Print("Updating item"), 'u');
// menu.AddItem("Delete item", () => ConsoleHelper.Print("Deleting item"), 'd');
// menu.AddItem("Exit", () => Environment.Exit(0), 'x');
//
// menu.Show();
