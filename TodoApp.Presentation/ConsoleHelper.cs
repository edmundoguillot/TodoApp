namespace TodoApp.Presentation;

public static class ConsoleHelper
{
    public static string GetSelection(string prompt, List<string> validOptions, string? errorMessage = null)
    {
        Console.WriteLine(prompt);
        var userInput = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userInput) || !validOptions.Contains(userInput, StringComparer.CurrentCultureIgnoreCase))
        {
            if (string.IsNullOrEmpty(userInput) || errorMessage is null)
                Console.WriteLine($"'{userInput ?? string.Empty}' is not a valid value, please choose from {string.Join(", ", validOptions)}");
            else
                Console.WriteLine($"{errorMessage}");
            
            userInput = Console.ReadLine();
        }
        return userInput;
    }
}