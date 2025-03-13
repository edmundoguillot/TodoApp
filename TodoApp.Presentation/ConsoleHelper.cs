namespace TodoApp.Presentation;

public static class ConsoleHelper
{
    public static string GetSelection(string prompt, List<string> validOptions, string? errorMessage = null)
    {
        Console.WriteLine(prompt);
        var userInput = Console.ReadLine();

        while (!validOptions.Contains(userInput, StringComparer.CurrentCultureIgnoreCase))
        {
            // the first condition is to handle the case where the user just press enter
            if (string.IsNullOrEmpty(userInput))
                Console.WriteLine($"Please enter a value. Choose from: {string.Join(", ", validOptions)}");
            else if (errorMessage == null)
                Console.WriteLine($"'{userInput}' is not a valid value, please choose from {string.Join(", ", validOptions)}");
            else
                Console.WriteLine($"{errorMessage}");
            
            userInput = Console.ReadLine();
        }
        return userInput;
    }
}