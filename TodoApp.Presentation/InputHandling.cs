using static TodoApp.Presentation.ConsoleHelper;

namespace TodoApp.Presentation;

public static class InputHandling
{
    public static T GetInput<T>(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine();
            try
            {
                return (T)Convert.ChangeType(userInput, typeof(T))!;
            }
            catch (Exception)
            {
                var errorString = TypeNameConverter(typeof(T));
                Print($"Please enter {errorString}", ConsoleColor.Red);
            }
        }
    }

    private static string TypeNameConverter(Type t)
    {
        switch (t.Name)
        {
            case "Int32":
            case "Decimal":
            case "Int64":
            case "Double":
                return "number";
            case "DateTime":
                return "date";
            default:
                return t.Name;
        }
    }
    
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

//An ok implementation, a bit long-winded
// public static bool GetBool2(string prompt)
// {
//     Console.WriteLine(prompt);
//     var userInput = Console.ReadLine();
//
//     while (true)
//     {
//         switch (userInput?.ToLower())
//         {
//             case "y":
//             case  "true":
//                 return true;   
//             case "n":
//             case  "false":
//                 return false;   
//         }
//         Console.WriteLine("Please enter a y/n or true/false: ");
//         userInput = Console.ReadLine();
//     }
// }
// //The prettiest one, this uses pattern matching with the 'is' keyword
// public static bool GetBool3(string prompt)
// {
//     Console.WriteLine(prompt);
//     var userInput = Console.ReadLine();
//
//     while (userInput?.ToLower() is not ("y" or "n" or "true" or "false"))
//     {
//         Console.WriteLine("Please enter a y/n or true/false: ");
//         userInput = Console.ReadLine();
//     }
//
//     return userInput!.ToLower() is "y" or "true";
// }