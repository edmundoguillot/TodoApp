using TodoApp.Presentation;

string choice = ConsoleHelper.GetSelection("Enter 'y' or 'n': ", [ "y", "n" ]);
ConsoleHelper.Print($"You selected: {choice}");