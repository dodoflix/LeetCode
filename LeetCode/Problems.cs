namespace LeetCode;

public class Problems
{
    public string Solve(int id)
    {
        switch (id)
        {
            case 13:
                Console.Write("Romanian number you want to convert:");
                return RomanToInt(Console.ReadLine()).ToString();
            default:
                return "Defined problem not found.";
        }
    }

    private int RomanToInt(string? s)
    {
        if (s == null)
            return 0;
        var charValues = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        var chars = s.ToCharArray();
        var numbers = chars.Select(x => charValues[x]).ToArray();
        var total = 0;
        for (var i = 0; i < numbers.Length; i++)
        {
            var number = numbers[i];
            var afterNumber = i + 1 >= numbers.Length ? 0 : numbers[i + 1];

            if (afterNumber > number)
            {
                total += afterNumber - number;
                i += 1;
            }
            else
            {
                total += number;
            }
        }
        return total;
    }
}