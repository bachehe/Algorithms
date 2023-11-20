using System.Text.RegularExpressions;

namespace exerc
{

    class Program
    {

        public static void Main(string[] args)
        {

            #region done
            //OrderByDescInt();
            //Console.WriteLine(Underscore());

            //int[] exampleTest1 = { 5, 5, 5, 4 };
            //Console.WriteLine(Int(exampleTest1));

            //string roman = "MMCVIX";
            //Console.WriteLine(RomanCalculator(roman));

            //var names = new[] { "Peter", "huj", "fuj", "sruj"};
            //Console.WriteLine(StringMethod(names));

            //long nb = 4820639;
            //Console.WriteLine(ExpandedForm(nb));

            //int startPriceOld = 2000;
            //int startPriceNew = 8000;
            //int savingPerMonth = 1000;
            //double percentLossByMonth = 1.5;
            //Console.WriteLine(CarRentalCalculator(startPriceOld, startPriceNew, savingPerMonth, percentLossByMonth));

            //string nb = "7842126960";
            //Console.WriteLine(ValidPhoneNumber(nb));

            //string[] smile = new[] { ":)", ":D", ":(" };
            //CountSimleys(smile);

            //int[,] board = new int[,] { { 1, 2, 2 }, { 0, 2, 0 }, { 0, 2, 0 } };
            //Console.WriteLine(TicTacToe(board));

            //string s = "mischtschenkoana";
            //Console.WriteLine(SolveForHighestNumber(s));
            //var temp = new[] { 1, 2, 1 };
            //TwoSum(temp, 2);

            //List<bool> numbers = new List<bool>()
            //{
            //    true, false, false, true, true 
            //};

            //Console.WriteLine(GetLongest(numbers));
            //test

            //int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            //int m = 3;
            //int[] nums2 = { 2, 5, 6, };
            //int n = 3;

            //Merge(nums1, m, nums2, n);

            //int[] nums = { 1, 1, 1, 2, 2, 3,3};
            //RemoveDuplicates(nums);
            //var nums = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            //ContainsDuplicate(nums);

            //string s = "nagara";
            //string t = "nagara";
            //Console.WriteLine(IsAnagram(s, t)); 

            //var s = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            //GroupAnagrams(s);

            //var nums = new int[] { 1, 1, 2, 2, 2, 3 };

            //TopKFrequent(nums, 2);

            //int[] nums = { 1, 2, 3, 4 };
            //Console.WriteLine(ProductExceptSelf(nums));
            #endregion done
            //char[][] sudokuBoard = new char[][]
            //{
            //    new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            //    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            //    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            //    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            //    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            //    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            //    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            //    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            //    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            //};

           // Console.WriteLine(IsValidSudoku(sudokuBoard));

        }

        #region done
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
            if (x > z)
                return x;
            else
                return z;
        }
        public static void TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] + nums[i++] == target)
                    Console.WriteLine(nums[i] + nums[i++]);

            }
        }
        public static int GetLongest(List<bool> values)
        {
            if (values == null || values.Count == 0)
                return 0;

            var longestSequence = 0;
            var currentSequence = 0;

            foreach (var boolean in values)
            {
                if (!boolean)
                    currentSequence = 0;
                else
                {
                    currentSequence++;
                    longestSequence = Math.Max(longestSequence, currentSequence);
                }
            }
            return longestSequence;
        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int index1 = m - 1;
            int index2 = n - 1;
            int mergedIndex = m + n - 1;

            while (index1 >= 0 && index2 >= 0)
            {
                if (nums1[index1] >= nums2[index2])
                {
                    nums1[mergedIndex] = nums1[index1];
                    index1--;
                }
                else
                {
                    nums1[mergedIndex] = nums2[index2];
                    index2--;
                }
                mergedIndex--;
            }
            while (index2 >= 0)
            {
                nums1[mergedIndex] = nums2[index2];
                index2--;
                mergedIndex--;
            }

        }
        public static int RemoveDuplicates(int[] nums)
        {
            int counter = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                    counter++;

                if (counter == 2)
                {
                    Console.WriteLine("tu");
                    counter = 0;
                }

            }

            return counter;
        }
        public static int Sorting(BinaryWriter writer, BinaryReader reader, int count)
        {
            var info = typeof(object).GetMethod("Equals", new[] { typeof(object), typeof(object) }).IsStatic;
            writer.Seek(-5, SeekOrigin.End);
            for (int i = 10; i < 15; i++)
            {
                writer.Write((byte)i);
            }
            reader.BaseStream.Position = 5;
            return reader.Read();

        }
        public static IEnumerable<int> Foo(IEnumerable<int> nbs, int count)
        {
            foreach (var n in nbs)
            {
                if (count > 0)
                {
                    count--;
                    yield return n;
                }
            }
        }
        public static bool ContainsDuplicate(int[] nums)
        {
            var result = false;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                    result = true;
            }

            Console.WriteLine(result);
            return result;
        }
        public static bool IsAnagram(string s, string t)
        {
            var charS = s.ToCharArray();
            var chartT = t.ToCharArray();

            if (charS.Length != chartT.Length)
                return false;

            Array.Sort(charS);
            Array.Sort(chartT);
            foreach (var item in charS)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < charS.Length; i++)
            {
                if (charS[i] != chartT[i])
                    return false;
            }

            return true;
        }
        public static IList<IList<string>> GroupAnagrams(string[] strs)
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
        public static int[] TopKFrequent(int[] nums, int k)
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
        public static int[] ProductExceptSelf(int[] nums)
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

        #endregion

        static bool IsValidSudoku(char[][] board)
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

        static bool IsValidSet(char[] set)
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
    }
}
