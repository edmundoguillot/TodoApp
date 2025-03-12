namespace TodoApp.Presentation;

public static class ConsoleHelper
{
    public static string GetSelection(string prompt, List<string> validOptions, string? errorMessage = null)
    {
        Console.WriteLine(prompt);
        var userInput = System.Console.ReadKey();

        while (!validOptions.Contains(userInput.KeyChar.ToString().ToLower()))
        {
            if (errorMessage != null)
                System.Console.WriteLine($"\n{errorMessage}");
            else
                System.Console.WriteLine();
            
            userInput = System.Console.ReadKey();
        }
        
        return userInput.KeyChar.ToString();
    }
}