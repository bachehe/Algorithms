using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.RoadMap
{
    public class SlidingWindow
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            var hashS1 = 0.0;
            var hashS2 = 0.0;

            for (int i = 0; i < s1.Length; i++)
            {
                hashS1 += s1[i] * Math.Pow(2, s1[i]);
                hashS2 += s2[i] * Math.Pow(2, s2[i]);
            }

            var l = 0;
            var r = s1.Length;

            while (r < s2.Length)
            {
                if (hashS1 == hashS2) return true;

                hashS2 -= s2[l] * Math.Pow(2, s2[l]);
                hashS2 += s2[r] * Math.Pow(2, s2[r]);
                l++;
                r++;
            }
            if (hashS1 == hashS2)
                return true;

            return false;
        }
        public int CharacterReplacement(string s, int k)
        {
            var dict = new Dictionary<char, int>();
            int left = 0, result = 0, mostFreq = 0;
            char[] arr = s.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                dict.TryGetValue(arr[i], out int count);
                dict[arr[i]] = count + 1;

                mostFreq = Math.Max(mostFreq, dict[arr[i]]);

                while ((i - left + 1) - mostFreq > k)
                {
                    dict[arr[left]] = dict[arr[left]] - 1;
                    left++;
                }
                result = Math.Max(result, i - left + 1);
            }
            return result;
        }
        public int LengthOfLongestSubstring(string s)
        {
            var max = 0;
            var count = 0;
            var word = String.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                word = String.Empty;
                count = 0;
                for (int j = i; j < s.Length; j++)
                {
                    if (!word.Contains(s[j]))
                    {
                        count++;
                        word += s[j];
                    }
                    else
                        break;
                }
                if (count > max)
                    max = count;
            }
            return max;
        }
        public static int MaxProfit(int[] prices)
        {
            int res = 0, profit = 0, buy = 0;
            int sell = 1;

            while (sell < prices.Length)
            {
                profit = prices[sell] - prices[buy];
                if (profit <= 0)
                    buy = sell;
                else
                {
                    if (profit > res) res = profit;
                }

                sell++;
            }
            Console.WriteLine(res);
            return res;
        }
    }
}
