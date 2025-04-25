namespace TodoApp.Presentation;

public static class ConsoleHelper
{
    public static string GetSelection(string prompt, List<string> validOptions, string? errorMessage = null)
    {
        string? ValidateFunction(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput) || !validOptions.Contains(userInput, StringComparer.CurrentCultureIgnoreCase))
            {
                return errorMessage ?? $"'{userInput}' is not a valid value, please choose from {string.Join(", ", validOptions)}";
            }
            return null;
        }

        return InputHandling.GetInput<string>(prompt, ValidateFunction);
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

