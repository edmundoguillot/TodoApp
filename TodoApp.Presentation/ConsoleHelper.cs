namespace TodoApp.Presentation;

public static class ConsoleHelper
{
    public static string GetSelection(string prompt, List<string> validOptions, string? errorMessage = null)
    {
        Console.WriteLine(prompt);
        var userInput = Console.ReadKey();

        while (!validOptions.Contains(userInput.KeyChar.ToString(), StringComparer.CurrentCultureIgnoreCase))
        {
            if (errorMessage == null)
                Console.WriteLine($"\n'{userInput.KeyChar}' is not a valid value, please choose from 'y' or 'n'");
            else
                Console.WriteLine($"\n{errorMessage}");
            
            userInput = Console.ReadKey();
        }
        
        return userInput.KeyChar.ToString();
    }
}