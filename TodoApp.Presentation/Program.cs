using ConsoleTables;
using TodoApp.Application.CreateTodoItem;
using TodoApp.Application.DeleteTodoItem;
using TodoApp.Application.GetAllTodoItems;
using TodoApp.Application.GetByIdTodoItem;
using TodoApp.Application.Models;
using TodoApp.Application.Persistence;
using TodoApp.Presentation;

var repository = new InMemoryTodoRepository();
var menu = new ConsoleMenu();
menu.AddItem("Create todo item", CreateTodoItem);
menu.AddItem("List item", ListItems);
menu.AddItem("Search item", SearchItem);
menu.AddItem("Delete item", DeleteItem);

menu.Show();
return;

void CreateTodoItem()
{
    var title = InputHandling.GetInput<string>("Enter the task title:");
    string? description = InputHandling.GetInput<string?>("Enter the task description (optional):");
    DateTime? completeBy = InputHandling.GetInput<DateTime?>("Enter a completion date (optional):");

    var command = new CreateTodoItemCommand(title!, description, completeBy);
    var handler = new CreateTodoItemCommandHandler(repository);

    try
    {
        var id = handler.Handle(command);
        ConsoleHelper.Print($"Todo item Id: {id.ToString()}", ConsoleColor.Blue);
    }
    catch (Exception e)
    {
        ConsoleHelper.Print(e.ToString(), ConsoleColor.Red);
    }
}

void ListItems()
{
    var handler = new GetAllTodoItemsQueryHandler(repository);
    var items = handler.Handle();
    if (items.Any())
        ConsoleTable.From(items).Write();
    else
        ConsoleHelper.Print("There are no items, try adding one", ConsoleColor.Red);
}

void SearchItem()
{
    Guid id = InputHandling.GetInput<Guid>("Enter the id of the item to find:");
    var handler = new GetByIdTodoItemQueryHandler(repository);
    var item = handler.Handle(id);
    if (item is null)
    {
        ConsoleHelper.Print("Item not found!", ConsoleColor.Red);
        return;
    }
    ConsoleTable.From([item]).Write();
}

void DeleteItem()
{
    Guid id = InputHandling.GetInput<Guid>("Enter the id of the item to delete:");

    var handler = new DeleteTodoItemCommandHandler(repository);
    var result = handler.Handle(id);
    
    if (result)
        ConsoleHelper.Print("Item deleted", ConsoleColor.Green);
    else
        ConsoleHelper.Print("Item not found", ConsoleColor.Red);
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
