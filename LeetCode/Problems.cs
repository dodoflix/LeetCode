namespace LeetCode;

public class Problems
{
    public string Solve(int id)
    {
        switch (id)
        {
            case 1:
                return "";
            case 13:
                Console.Write("Romanian number you want to convert:");
                return RomanToInt(Console.ReadLine()).ToString();
            default:
                return "Defined problem not found.";
        }
    }

    /*
     *  Problem 1:
     *  https://leetcode.com/problems/two-sum/
     *  https://leetcode.com/problems/two-sum/submissions/876035668/
     */
    private static int[] TwoSum(int[] nums, int target)
    {
        for (var a = 0; a < nums.Length; a++)
        {
            for (var b = a + 1; b < nums.Length; b++)
            {
                if (nums[a] + nums[b] == target)
                {
                    return new[] { a, b };
                }
            }
        }

        return Array.Empty<int>();
    }

    /*
     *  Problem 13:
     *  https://leetcode.com/problems/roman-to-integer/
     *  https://leetcode.com/problems/roman-to-integer/submissions/876021956/
     */
    private static int RomanToInt(string? s)
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