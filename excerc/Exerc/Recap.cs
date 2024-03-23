using System.Text;

namespace excerc.Exerc;
public class Recap
{
    public int[] TwoSum(int[] nums, int target)
    {
        //updates
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    for (int j = 0; j < nums.Length; j++)
        //    {
        //        if (nums[i] + nums[j] == target)
        //            return new int[2] { nums[i], nums[j] };
        //    }
        //}
        //return new int[0];

        //string originalString = "72";

        //// PadLeft with a width of 6 characters
        //var dupa = originalString.PadLeft(6, '0');
        //string paddedString2 = originalString.PadRight(6, '0');

        var original = "123456";
        var original2 = "123456";

        var sub1 = original.Substring(0, 2);
        original2.Substring(0, 2);
        Console.WriteLine(sub1) ;
        Console.WriteLine(original2) ;



        //Console.WriteLine(dupa);  // Output: "1234567"
        //Console.WriteLine(paddedString2 +  " right");  // Output: 7

        return new[] {1};
    }
    public bool IsPalindrome(int x)
    {
        var val = x.ToString().ToCharArray();
        var sb = new StringBuilder();
        var s2 = new StringBuilder();
        for (int i = val.Length - 1; i >= 0; i--)
        {
            sb.Append(val[i]);
        }
        s2.Append(x);

        return s2.Equals(sb);
    }
    public int RomanToInt(string s)
    {
        var res = 0;
        Dictionary<char, int> romanDict = new ()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int currentValue = romanDict[s[i]];

            if (i < s.Length - 1 && currentValue < romanDict[s[i + 1]])
                res -= currentValue;

            else
                res += currentValue;
        }
        Console.WriteLine(res);

        return 0;
    }
}

