using System;
using System.Collections.Generic;
using System.Linq;

namespace exerc
{
    class Program
    {

        public static void Main(string[] args)
        {
            //OrderByDescInt();
            //Console.WriteLine(Underscore());

            //int[] exampleTest1 = { 5, 5, 5, 4 };
            //Console.WriteLine(Int(exampleTest1));

            //string roman = "MMCVIX";
            //Console.WriteLine(RomanCalculator(roman));

            //var names = new[] { "Peter", "huj", "fuj", "sruj" };
            //Console.WriteLine(StringMethod(names));

            long nb = 35;
            Console.WriteLine(ExpandedForm(nb));
            
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
    }
}