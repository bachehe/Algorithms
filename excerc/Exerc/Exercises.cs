﻿using System.Text;
using System.Text.RegularExpressions;
using excerc.Exerc;

namespace exerc
{
    public class Exercises
    {
        public string ConvertToTitle(int columnNumber)
        {

            string alphabet = "#ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var res = new List<char>();

            int j = 0;
            while (columnNumber > 0)
            {
                res.Add(alphabet[columnNumber % 26 == 0 ? 26 : columnNumber % 26]);
                columnNumber = (columnNumber - (columnNumber % 26 == 0 ? 26 : columnNumber % 26)) / 26;
                j++;
            }

            alphabet = "";
            for (int i = res.Count - 1; i >= 0; i--)
            {
                alphabet = alphabet + res[i];
            }

            return alphabet;
        }
        public static bool IsHappy(int n)
        {
            var set = new HashSet<int>();

            while (n != 1)
            {
                string str = n.ToString();
                int sum = 0;

                foreach (char c in str)
                {
                    int digit = c - '0';
                    sum += digit * digit;
                }

                if (set.Contains(sum))
                    return false;

                set.Add(sum);
                n = sum;
            }

            return true;
        }
        public static int MajorityElement(int[] nums)
        {
            return nums.GroupBy(i => i)
                .OrderByDescending(g => g.Count())
                .Take(1)
                .Select(g => g.Key)
                .First();
        }
        public static int SingleNumber(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i = i + 2)
            {
                if (i == nums.Length - 1) return nums[i];
                if (nums[i] != nums[i + 1]) return nums[i];
            }
            return 0;
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
        public static bool IsPalindrome(string s)
        {
            //vals
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
    }
}