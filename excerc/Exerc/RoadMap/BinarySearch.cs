using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.RoadMap
{
    public class BinarySearch
    {
        public int Search(int[] nums, int target) => Array.IndexOf(nums, target);
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

    }
    public class TimeMap
    {
        private Dictionary<string, List<(int Version, string Value)>> _mapper = new();
        public TimeMap() { }

        public void Set(string key, string value, int timestamp)
        {
            if (_mapper.ContainsKey(key))
                _mapper[key].Add((timestamp, value));

            else
                _mapper[key] = new List<(int Version, string Value)>() { (timestamp, value) };
        }

        public string Get(string key, int timestamp)
        {
            if (!_mapper.ContainsKey(key))
                return string.Empty;

            var vals = _mapper[key];

            var l = 0;
            var r = vals.Count - 1;

            while (l <= r)
            {
                var mid = (r + l) / 2;

                if (vals[mid].Version == timestamp)
                    return vals[mid].Value;
                else if (vals[mid].Version > timestamp)
                    r = mid - 1;
                else l = mid + 1;
            }

            return l == 0 ? string.Empty : vals[l - 1].Value;
        }
    }
}
