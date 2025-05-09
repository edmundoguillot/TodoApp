namespace TodoApp.Presentation;

public static class ConsoleHelper
{
    public static string GetSelection(string prompt, List<string> validOptions, string? errorMessage = null)
    {
        var optionValues = validOptions.Select(x => $"'{x}'").ToArray();
        return InputHandling.GetInput<string?>(prompt, Validate)!;
        
        string? Validate(string? value) =>
            validOptions.Contains(value ?? string.Empty, StringComparer.OrdinalIgnoreCase)
                ? null
                : $"'{value ?? string.Empty}' is not a valid option. Please choose from {string.Join(" or ", optionValues)}";
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

