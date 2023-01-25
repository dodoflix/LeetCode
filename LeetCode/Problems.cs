namespace LeetCode;

public class Problems
{
    public string Solve(int id)
    {
        int startTime;
        int runTime;
        switch (id)
        {
            case 1:
                // TODO Problem 1 user input
                // return TwoSum(Console.ReadLine().Split(',').Select(x => Convert.ToInt32(x)).ToArray(), Convert.ToInt32(Console.ReadLine()));
                return "TODO";
            case 2:
                // TODO Problem 2 user input
                Console.Write("First ListNode (1,2,3):");
                var l1 = Console.ReadLine();
                var l1Temp = new List<ListNode>();
                foreach (var num in l1.Split(',').Reverse())
                {
                    l1Temp.Add(new ListNode(Convert.ToInt32(num), l1Temp.Count != 0 ? l1Temp.Last() : null));
                }
                
                Console.Write("Second ListNode (1,2,3):");
                var l2 = Console.ReadLine();
                var l2Temp = new List<ListNode>();
                foreach (var num in l2.Split(',').Reverse())
                {
                    l2Temp.Add(new ListNode(Convert.ToInt32(num), l2Temp.Count != 0 ? l2Temp.Last() : null));
                }

                startTime = DateTime.Now.Millisecond;
                var newListNode = AddTwoNumbers(l1Temp.Last(), l2Temp.Last());
                runTime = DateTime.Now.Millisecond - startTime;

                var numbers = new List<string>();

                while (true)
                {
                    numbers.Add(newListNode.val.ToString());
                    if (newListNode.next == null)
                        break;
                    newListNode = newListNode.next;
                }
                
                return $"[{string.Join(',', numbers.ToArray())}] ({runTime}ms)";
            case 13:
                Console.Write("Romanian number you want to convert:");
                var input = Console.ReadLine();
                
                startTime = DateTime.Now.Millisecond;
                var result = RomanToInt(input).ToString();
                runTime = DateTime.Now.Millisecond - startTime;
                
                return $"{result} ({runTime}ms)";
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
     *  Problem 2:
     *  https://leetcode.com/problems/add-two-numbers/
     */
    private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var l1Temp = l1;
        var l2Temp = l2;

        var l1String = "";
        var l2String = "";

        var l1Done = false;
        var l2Done = false;
        
        while (true)
        {
            if (!l1Done)
            {
                l1String = $"{l1Temp.val}{l1String}";
                if (l1Temp.next != null)
                    l1Temp = l1Temp.next;
                else
                    l1Done = true;
            }

            if (!l2Done)
            {
                l2String = $"{l2Temp.val}{l2String}";
                if (l2Temp.next != null)
                    l2Temp = l2Temp.next;
                else
                    l2Done = true;
            }

            if (l1Done & l2Done)
                break;
        }
        
        var l3Temp = (Convert.ToInt32(l1String) + Convert.ToInt32(l2String)).ToString().ToCharArray();
        
        var listNodes = new List<ListNode>();

        foreach (var i in l3Temp.Reverse())
        {
            listNodes.Add(new ListNode(Convert.ToInt32((i.ToString())), listNodes.Count != 0 ? listNodes.Last() : null));
        }

        return listNodes.Last();
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

    /*
     *  Problem 2 ListNode Class
     */
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}