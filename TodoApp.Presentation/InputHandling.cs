namespace TodoApp.Presentation;

public static class InputHandling
{
    public static int GetInt(string prompt)
    {
        Console.WriteLine(prompt);
        var userInput = Console.ReadLine();
        var validInt = int.TryParse(userInput, out var number);
        
        while (!validInt)
        {
            Console.WriteLine("Please enter a valid integer: ");
            userInput = Console.ReadLine();
            validInt = int.TryParse(userInput, out number);
        }
        
        // option 2
        // while (!validInt)
        // {
        //     try
        //     {
        //         var userInput = Console.ReadLine();
        //         var validInt = false;
        //         number = int.Parse(userInput);
        //         validInt = true;
        //     }
        //     catch
        //     {
        //         Console.WriteLine("Please enter a valid integer: ");
        //     }
        // }

        return number;
    }

    public static bool GetBool(string prompt)
    {
        Console.WriteLine(prompt);
        var userInput = Console.ReadLine();
        var result = false;

        var success = bool.TryParse(userInput, out result);
        var yes = userInput?.ToLower() == "y";
        var no = userInput?.ToLower() == "n";

        while (!success && !yes && !no)
        {
            Console.WriteLine("Please enter a y/n or true/false: ");
            userInput = Console.ReadLine();
            success = bool.TryParse(userInput, out result);
            yes = userInput?.ToLower() == "y";
            no = userInput?.ToLower() == "n";
        }

        return yes || result;
    }
}