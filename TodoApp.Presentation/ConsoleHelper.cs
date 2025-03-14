namespace TodoApp.Presentation;

public static class ConsoleHelper
{
    public static string GetSelection(string prompt, List<string> validOptions, string? errorMessage = null)
    {
        Console.WriteLine(prompt);
        var userInput = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userInput) || !validOptions.Contains(userInput, StringComparer.CurrentCultureIgnoreCase))
        {
            Print(errorMessage ?? $"'{userInput ?? string.Empty}' is not a valid value, please choose from {string.Join(", ", validOptions)}");
            userInput = Console.ReadLine();
        }
        
        return userInput;
    }

    public static void Print(string message, ConsoleColor color = ConsoleColor.Gray, bool newLine = true)
    {
        Console.ForegroundColor = color;
        if (newLine)
            Console.WriteLine();
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

