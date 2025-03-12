using TodoApp.Presentation;

string choice = ConsoleHelper.GetSelection("Enter 'y' or 'n': ", [ "y", "n" ]);
Console.WriteLine($"\nYou selected: {choice}");