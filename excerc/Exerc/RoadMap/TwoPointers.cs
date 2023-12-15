using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.RoadMap
{
    public class TwoPointers
    {
        public bool IsPalindrome(string s)
        {
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();
            foreach (var i in s.ToLower().ToCharArray())
            {
                if (char.IsLetter(i) || char.IsNumber(i))
                    sb.Append(i);
            }

            foreach (var i in sb.ToString().Reverse())
            {
                sb2.Append(i);
            }

            return sb.Equals(sb2);
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new[] { i, j };
                }
            }
            return new int[] { };
        }
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();

            Array.Sort(nums);

            var res = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;

                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int leftSide = i + 1;
                int rightSide = nums.Length - 1;

                while (leftSide < rightSide)
                {
                    int sum = nums[i] + nums[leftSide] + nums[rightSide];

                    if (sum == 0)
                    {
                        res.Add(new List<int>() { nums[i], nums[leftSide], nums[rightSide] });
                        while (leftSide < rightSide && nums[leftSide] == nums[leftSide + 1]) leftSide++;
                        while (leftSide < rightSide && nums[rightSide] == nums[rightSide - 1]) rightSide--;
                        leftSide++;
                        rightSide--;
                    }
                    else if (sum < 0) leftSide++;
                    else rightSide--;
                }
            }

            return res;
        }
        public static int MaxArea(int[] height)
        {
            int res = 0;
            int field;
            int i = 0;
            int j = height.Length - 1;
            int hj;
            int hi;

            while (j > i)
            {
                hi = height[i];
                hj = height[j];

                if (hi > hj)
                {
                    field = hj * (j - i);
                    j--;
                }
                else
                {
                    field = hi * (j - i);
                    i++;
                }

                if (field > res) res = field;

            }

            return res;
        }
        public static int Trap(int[] height)
        {
            int res = 0;
            int max = 0;

            int current = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > max) max = height[i];

                if (height[i] > current) current = height[i];
                else if (height[i] < current)
                {
                    res += current - height[i];
                }
            }

            current = 0;
            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (height[i] == max) break;

                if (height[i] > current) current = height[i];

                res -= max - current;
            }

            return res;
        }

    }
}
