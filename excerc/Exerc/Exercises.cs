﻿using System.Text;
using System.Text.RegularExpressions;
using excerc.Exerc;

namespace exerc
{
    public class Exercises
    {
        static List<string> resParenthesis = new List<string>();

        #region done
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var res = 0d;
            int x = nums1.Length;
            int y = nums2.Length;
            int low = 0, high = x;

            if (x > y)
            {
                int[] temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int partY = (x + y + 1) / 2 - mid;

                int maxX = (mid == 0) ? int.MinValue : nums1[mid - 1];
                int minX = (mid == x) ? int.MaxValue : nums1[mid];

                int maxY = (partY == 0) ? int.MinValue : nums2[partY - 1];
                int minY = (partY == y) ? int.MaxValue : nums2[partY];

                if (maxX <= minY && maxY <= minX)
                {
                    if ((x + y) % 2 == 0)
                    {
                        res = (double)(Math.Max(maxX, maxY)) + Math.Min(minX, minY);
                        break;
                    }
                    else
                    {
                        res = (double)Math.Min(maxX, minY);
                        break;
                    }
                }
                else if (maxX > minX) high = mid - 1;
                else low = mid + 1;
            }
            Console.WriteLine(res);
            return res;
        }
        public static int Searching(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[l] <= nums[mid])
                {
                    if (nums[l] <= target && target < nums[mid]) r = mid - 1;

                    else l = mid + 1;

                }
                else
                {
                    if (nums[mid] < target && target <= nums[r]) l = mid + 1;

                    else r = mid - 1;

                }
            }

            return -1;
        }
        public static int FindMin(int[] nums)
        {
            var l = 0;
            var r = nums.Length - 1;

            while (l < r)
            {

                int mid = (l + r) / 2;
                if (nums[mid] > nums[r])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }

            return nums[l];
        }
        public static int MinEatingSpeed(int[] piles, int h)
        {
            var kmin = 1;
            var kmax = piles.Max();

            while (kmax > kmin)
            {
                int mid = kmin + (kmax - kmin) / 2;
                int totalHours = 0;

                foreach (int pile in piles)
                    totalHours += (int)Math.Ceiling((double)pile / mid);

                if (totalHours <= h) kmax = mid;

                else kmin = mid + 1;
            }

            return kmin;
        }
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == target) return true;
                }
            }

            return false;
        }
        public static int Search(int[] nums, int target) => Array.IndexOf(nums, target);
        public static int LargestRecangle(int[] heights)
        {
            int res = 0;
            var stack = new Stack<int>();

            for (int i = 0; i <= heights.Length; i++)
            {
                var height = i < heights.Length ? heights[i] : 0;

                while (stack.Any() && heights[stack.Peek()] > height)
                {
                    var currHeight = heights[stack.Pop()];
                    var prevIndex = stack.Count == 0 ? -1 : stack.Peek();

                    res = Math.Max(res, currHeight * (i - 1 - prevIndex));
                }

                stack.Push(i);
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
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Count() < 3) return new List<IList<int>>();

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
        public static int LargestRectangleArea(int[] heights)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < heights.Length - 1; i++)
            {
                while (heights[i] - heights[i + 1] > 0)
                {
                    i++;
                    var temp = heights[i] - heights[i + 1];
                    stack.Push(temp + heights[i + 1]);
                    if (stack.Count() > heights.Length) break;
                }
            }
            Console.WriteLine(stack.Max());

            return stack.Max();
        }
        public static int CarFleet(int target, int[] position, int[] speed)
        {
            var fleet = 1;
            int sl = speed.Length;
            int pl = position.Length;

            if (pl != sl)
                return 1;

            Array.Sort(position, speed, Comparer<int>.Create((b, a) => a - b));

            for (int i = 0; i < sl - 1; i++)
            {
                if (speed[i] == 0) continue;

                if (speed[i + 1] == 0)
                {
                    fleet++;
                    continue;
                }

                double x = (double)(target - position[i]) / speed[i];
                double y = (double)(target - position[i + 1]) / speed[i + 1];

                if (x < y) fleet++;

                else
                {
                    position[i + 1] = position[i];
                    speed[i + 1] = speed[i];
                }
            }

            return fleet;
        }
        public static int[] DailyTemperatures(int[] temperatures)
        {
            var length = temperatures.Length;
            var res = new int[length];

            for (int i = 0; i < length - 1; i++)
            {
                if (temperatures[i] < temperatures[i + 1])
                {
                    res[i] = 1;
                    continue;
                }

                else
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        if (temperatures[i] < temperatures[j])
                        {
                            res[i] = j - i;
                            break;
                        }
                    }
                }
            }

            return res;
        }
        public static IList<string> GenerateParenthesis(int n)
        {
            Recursive(" ", n, 0);
            return resParenthesis;
        }
        public static void Recursive(string current, int remaining, int leftCount)
        {
            if (remaining == 0 && leftCount == 0)
            {
                resParenthesis.Add(current);
                return;
            }
            if (remaining > 0)
                Recursive(current + "(", remaining - 1, leftCount + 1);
            if (leftCount > 0)
                Recursive(current + ")", remaining, leftCount - 1);
        }
        public static int EvalRPN(string[] tokens)
        {
            var res = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                int left;
                int right;

                switch (tokens[i])
                {
                    case "+":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left + right);
                        break;
                    case "-":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left - right);
                        break;
                    case "*":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left * right);
                        break;
                    case "/":
                        right = res.Pop();
                        left = res.Pop();
                        res.Push(left / right);
                        break;
                    default:
                        res.Push(int.Parse(tokens[i]));
                        break;
                }
            }
            Console.WriteLine(res.Pop());
            return res.Pop();
        }
        public static void Bubble()
        {
            var s = new int[] { 1, 3, 2 };
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (s[j] > s[j + 1])
                    {
                        var temp = s[j];
                        s[j] = s[j + 1];
                        s[j + 1] = temp;
                    }
                }
            }
            foreach (var x in s)
            {
                Console.WriteLine(x);
            }
        }
        public static int[] TwoSums(int[] numbers, int target)
        {
            //var res = new int[2];

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    for (int j = i+1; j < numbers.Length; j++)
            //    {
            //        if (numbers[i] + numbers[j] == target)
            //        {
            //            res[0] = i+1;
            //            res[1] = j + 1;
            //            return res;
            //        }
            //        if (numbers[i] + numbers[j] > target) break;
            //    }
            //}
            //return res;           
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
        public static bool IsPalindrome(string s)
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
        /// <summary>
        ///Your task is to make a function that can take any non-negative integer as an argument
        ///and return it with its digits in descending order.Essentially, rearrange the digits
        ///to create the highest possible number.Examples:Input: 42145 Output: 54421
        /// </summary>
        public static int OrderByDescInt()
        {
            var num = 42145;

            var nms = new String(num.ToString()
                     .Select(x => new { Character = x, Number = (int)Char.GetNumericValue(x) })
                     .OrderByDescending(x => x.Number)
                     .Select(x => x.Character).ToArray());

            Console.WriteLine(nms);
            return Convert.ToInt32(nms);
        }
        /// <summary>
        /// Add udnerscore under every char in given sequence
        /// </summary>
        /// <returns></returns>
        public static string[] Underscore()
        {
            var s = "abcdef";
            return s.SelectMany((x, i) => i % 2 == 0 ? new string[] { $"{x}{(i < s.Length - 1 ? s[i + 1] : '_')}" } : new string[0]).ToArray();
        }
        /// <summary>
        /// You are given an array (which will have a length of at least 3, but could be very large) containing integers. The array is either 
        /// entirely comprised of odd integers or entirely comprised of even ///integers except for a single integer N. Write a method that takes the array as an argument and returns this "outlier" N.
        /// </summary>
        public static int Int(int[] integers)
        {
            #region XD
            //int oddNb = 0;
            //int[] oddArrayValue = new int[oddNb];
            //int[] oddArray = new int[oddNb];

            //int evenNb = 0;
            //int[] evenArrayValue = new int[evenNb];
            //int[] evenArray = new int[evenNb];

            //foreach (var i in integers)
            //{
            //    if (i % 2 == 0)
            //    {
            //        oddNb++;
            //        oddArrayValue = oddArray.Concat(new int[] { i }).ToArray();
            //        Console.WriteLine(i);

            //    }
            //    else
            //    {
            //        evenNb++;
            //        evenArrayValue = evenArray.Concat(new int[] { i }).ToArray();
            //        Console.WriteLine(i);
            //    }
            //}
            //if (oddNb > evenNb)
            //{
            //    foreach (var o in oddArrayValue)
            //    {
            //        Console.WriteLine(o);
            //    }
            //}
            //else
            //{
            //    foreach (var e in evenArrayValue)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}
            #endregion
            int x = 0;
            int z = 0;

            int xCount = 0;
            int zCount = 0;

            foreach (var i in integers)
            {
                if (i < 0)
                    continue;

                if (i % 2 != 0)
                {
                    int[] arrOdd = new int[i];
                    xCount = arrOdd.Count();
                    x = i;
                }
                else
                {
                    int[] arrEven = new int[i];
                    zCount = arrEven.Count();
                    z = i;
                }


            }
            if (xCount > zCount)
            {
                return x;
            }
            else
            {
                return z;
            }
            Console.WriteLine("-----------");
        }
        /// <summary>
        /// Create a function that takes a Roman numeral as its argument and returns its value as 
        /// a numeric decimal integer. You don't need to validate the form of the Roman numeral.
        /// </summary>
        public static int RomanCalculator(string roman)
        {

            var result = 0;
            var dict = new Dictionary<string, int>()
            {
                {"I", 1 },
                {"V", 5 },
                {"X", 10 },
                {"L", 50 },
                {"C", 100 },
                {"D", 500 },
                {"M", 1000 },
            };

            var split = String.Join(" ", roman.Split(' '));

            foreach (var i in split)
            {
                int test;
                dict.TryGetValue(i.ToString(), out test);
                result = result + test;
            }
            return result;
        }
        /// <summary>
        /// Implement the function which takes an array containing the names of people that like an item. It must return the display text as shown in the examples:
        /// </summary>
        public static string StringMethod(string[] name)
        {
            int value = 0;
            foreach (var n in name)
            {
                value++;

            }
            switch (value)
            {
                case 0:
                    Console.WriteLine("no one likes this");
                    break;

                case 1:
                    Console.WriteLine($"{name[0]} likes this");
                    break;

                case 2:
                    Console.WriteLine($"{name[0]} and {name[1]} like this");
                    break;

                case 3:
                    Console.WriteLine($"{name[0]}, {name[1]} and {name[2]} like this");
                    break;

                case 4:
                    Console.WriteLine($"{name[0]}, {name[1]} and {name.Count() - 2} others like this");
                    break;

                default:
                    break;
            }


            return string.Empty;
        }
        /// <summary>
        /// You will be given a number and you will need to return it as a string in Expanded Form. For example:
        /// 12 = "10+2"
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ExpandedForm(long num)
        {
            var str = num.ToString();
            return String.Join(" + ", str
                .Select((x, i) => char.GetNumericValue(x) * Math.Pow(10, str.Length - i - 1))
                .Where(x => x > 0));
        }
        /// <summary>
        /// He thinks he can save $1000 each month but the prices of his old car and of the new one decrease of 1.5 percent per month. 
        /// Furthermore this percent of loss increases of 0.5 percent at the end of every two months. Our man finds it difficult to make all these calculations.
        /// </summary>
        /// <param name="startPriceOld"></param>
        /// <param name="startPriceNew"></param>
        /// <param name="savingPerMonth"></param>
        /// <param name="percentLossByMonth"></param>
        /// <returns></returns>
        public static int[] CarRentalCalculator(int startPriceOld, int startPriceNew,
                                                int savingPerMonth, double percentLossByMonth)
        {
            int month = 0;
            double priceNew = startPriceNew;
            double priceOld = startPriceOld;
            double savings = priceOld;
            while (savings < priceNew)
            {
                month++;
                if (month % 2 == 0) percentLossByMonth += 0.5;
                priceOld -= priceOld * (percentLossByMonth / 100);
                priceNew -= priceNew * (percentLossByMonth / 100);
                savings = month * savingPerMonth + priceOld;
            }

            return new int[] { month, (int)(Math.Round(savings - priceNew)) };
        }
        /// <summary>
        /// Write a function that accepts a string, and returns true if it is in the form of a phone number.
        ///Assume that any integer from 0-9 in any of the spots will produce a valid phone number.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool ValidPhoneNumber(string phoneNumber)
        {
            var res = Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");

            bool valid = Regex.IsMatch(res, @"\(\d\d\d\)\s[A-Za-z0-9]+-[A-Za-z0-9]+");
            if (valid)
                return true;
            else
                return false;

            //return Regex.IsMatch(phoneNumber, @"^\(\d{3}\) \d{3}-\d{4}\z");
        }
        /// <summary>
        /// Given an array (arr) as an argument complete the function countSmileys that should return the total number of smiling faces.
        /// </summary>
        /// <param name="smileys"></param>
        /// <returns></returns>
        public static int CountSimleys(string[] smileys)
        {
            string[] validFaces = new[] { ":)", ";)", ";D", ":D", ";-D", ";~D", ":~D", ":-D", ";-)", ":~)", ":-)" };

            var test = smileys.Intersect(validFaces);
            int i = 0;
            foreach (var t in test)
            {
                i++;
            }

            Console.WriteLine(i);
            if (i == 0)
                return 0;

            return i;
        }
        /// <summary>
        /// XD
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static int TicTacToe(int[,] board)
        {
            if (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2] && board[0, 0] == 1)
                return 1;
            else if (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2] && board[0, 0] == 2)
                return 2;
            else if (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] && board[0, 0] == 1)
                return 1;
            else if (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] && board[0, 0] == 2)
                return 2;
            else if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && board[0, 1] == 1)
                return 1;
            else if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && board[0, 1] == 2)
                return 2;
            else if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] && board[1, 0] == 1)
                return 1;
            else if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] && board[1, 0] == 2)
                return 2;
            else if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] && board[0, 2] == 1)
                return 1;
            else if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] && board[0, 2] == 2)
                return 2;
            else if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 0] && board[2, 0] == 1)
                return 1;
            else if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 0] && board[2, 0] == 2)
                return 2;
            else if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] == 1)
                return 1;
            else if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] == 2)
                return 2;
            else if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] == 1)
                return 1;
            else if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] == 2)
                return 2;
            else
                return 0;

        }
        /// <summary>
        /// Given a lowercase string that has alphabetic characters only and no spaces,
        /// return the highest value of consonant substrings. Consonants are any letters of the alphabet except "aeiou".
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int SolveForHighestNumber(string s)
        {
            if (s.Length == 0)
                return 0;
            int tempMax = 0, maxSoFar = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
                {
                    maxSoFar = max(tempMax, maxSoFar);
                    tempMax = 0;
                }
                else
                {
                    tempMax += s[i] - 'a' + 1;
                }
            }

            return max(maxSoFar, tempMax);
        }
        /// <summary>
        /// SolveForHighestNumber extension
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static int max(int x, int z)
        {
            return z > x ? z : x;
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
        public static int LengthOfLongestSubstring(string s)
        {
            var word = string.Empty;
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (!word.Contains(s[j]))
                    {
                        word += s[j];
                        count++;
                    }
                }
            }
            return count;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry = 0)
        {
            if (l1 == null && l2 == null && carry == 0) return null;

            int total = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
            carry = total / 10;
            return new ListNode(total % 10, AddTwoNumbers(l1?.next, l2?.next, carry));
        }
        #endregion
    }
}