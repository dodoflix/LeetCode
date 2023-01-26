namespace LeetCode;

public static class InputHelper
{
    private static bool IsStringEmpty(string? input)
    {
        return input == string.Empty | input == "" | input == null;
    }

    private static string InputTillNotNull(string message)
    {
        var input = string.Empty;
        while (IsStringEmpty(input))
        {
            Console.Write(message);
            input = Console.ReadLine();
            if(IsStringEmpty(input))
                Console.WriteLine("You entered an empty input, please enter an valid input.");
        }

        return input;
    }
    
    public static string ReadString(string message)
    {
        Console.WriteLine("Input Type: String");
        Console.WriteLine("Example: hello world!");
        
        var input = InputTillNotNull(message);
        
        return input;
    }

    public static int ReadInt(string message)
    {
        Console.WriteLine("Input Type: Integer");
        Console.WriteLine("Example: 1");

        var input = InputTillNotNull(message);

        return Convert.ToInt32(input);
    }

    public static string[] ReadStringArray(string message)
    {
        Console.WriteLine("Input Type: String Array");
        Console.WriteLine("Example: hello,world");
        
        var input = InputTillNotNull(message);

        input = input.Trim();
        
        return input.Split(',').ToArray();
    }
    
    public static int[] ReadIntArray(string message)
    {
        Console.WriteLine("Input Type: Integer Array");
        Console.WriteLine("Example: 1,2,3");
        
        var input = InputTillNotNull(message);

        input = input.Trim();
        
        return input.Split(',').Select(int.Parse).ToArray();
    }
}