using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.Categories
{
    public class ArraysAndHash
    {
        public bool IsAnagram(string s, string t)
        {
            var charS = s.ToCharArray();
            var chartT = t.ToCharArray();

            if (charS.Length != chartT.Length)
                return false;

            Array.Sort(charS);
            Array.Sort(chartT);

            for (int i = 0; i < charS.Length; i++)
            {
                if (charS[i] != chartT[i])
                    return false;
            }

            return true;
        }
        public bool ContainsDuplicate(int[] nums)
        {
            var result = false;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                    result = true;
            }
            return result;
        }
        public static int[] TwoSums(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target) break;
                if (sum < target) left++;
                if (sum > target) right--;
            }
            return new int[] { left + 1, right + 1 };


        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagramGroups = new Dictionary<string, List<string>>();

            foreach (var word in strs)
            {
                var chars = word.ToCharArray();
                Array.Sort(chars);

                var sorted = new string(chars);

                if (!anagramGroups.ContainsKey(sorted))
                    anagramGroups[sorted] = new List<string>();

                anagramGroups[sorted].Add(word);

            }
            return new List<IList<string>>(anagramGroups.Values);
        }
        public int[] TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            var bucket = new List<int>[nums.Length + 1];

            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            var sortedDict = dict.OrderByDescending(x => x.Value);

            var res = new List<int>();
            foreach (var i in sortedDict)
            {
                res.Add(i.Key);
                k--;
                if (k == 0)
                    break;
            }

            return res.ToArray();
        }
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] leftProducts = new int[nums.Length];
            int[] rightProducts = new int[nums.Length];
            int[] result = new int[nums.Length];

            int leftProduct = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                leftProducts[i] = leftProduct;
                leftProduct *= nums[i];
            }

            int rightProduct = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                rightProducts[i] = rightProduct;
                rightProduct *= nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
                result[i] = leftProducts[i] * rightProducts[i];

            return result;
        }
        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!IsValidSet(board[i]))
                {
                    return false;
                }
            }

            for (int j = 0; j < 9; j++)
            {
                char[] column = new char[9];
                for (int i = 0; i < 9; i++)
                {
                    column[i] = board[i][j];
                }

                if (!IsValidSet(column))
                {
                    return false;
                }
            }

            for (int blockRow = 0; blockRow < 3; blockRow++)
            {
                for (int blockCol = 0; blockCol < 3; blockCol++)
                {
                    char[] subgrid = new char[9];
                    int index = 0;

                    for (int i = blockRow * 3; i < (blockRow + 1) * 3; i++)
                    {
                        for (int j = blockCol * 3; j < (blockCol + 1) * 3; j++)
                        {
                            subgrid[index++] = board[i][j];
                        }
                    }

                    if (!IsValidSet(subgrid))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public bool IsValidSet(char[] set)
        {
            HashSet<char> seen = new HashSet<char>();
            foreach (char c in set)
            {
                if (c != '.' && !seen.Add(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static int LongestConsecutive(int[] nums)
        {
            var set = new HashSet<int>(nums);
            int max = 0;

            foreach (var num in nums)
            {
                if (!set.Contains(num - 1))
                {
                    int current = num;
                    int streak = 1;

                    while (set.Contains(current + 1))
                    {
                        current++;
                        streak++;
                    }
                    max = Math.Max(max, streak);
                }
            }
            Console.WriteLine(max);
            return max;
        }
    }
}
