using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T349_MathProblems
    {
        public T349_MathProblems()
        {
        }

        #region T349 求两个数组的交集。输出的结果，如果有重复的，只显示一个。

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            List<int> output = new List<int>();
            int[] lesser = nums1.Length <= nums2.Length ? nums1 : nums2;
            int[] larger = lesser == nums1 ? nums2 : nums1;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < lesser.Length; i++)
            {
                if (!dict.ContainsValue(lesser[i]))
                {
                    dict.Add(i, lesser[i]);
                }
            }
            for (int i = 0; i < larger.Length; i++)
            {
                if (dict.ContainsValue(larger[i]) && !output.Contains(larger[i]))
                {
                    output.Add(larger[i]);
                }
            }
            return output.ToArray();

            //------------可以使用.NET提供的Intersect()方法来实现...
            //return nums1.Intersect(nums2).ToArray();
        }

        #endregion

        #region T350 求两个数组的交集。输出的结果中每个元素出现的次数，应与元素在两个数组中出现的次数一致

        public int[] Intersect_II(int[] nums1, int[] nums2)
        {
            List<int> output = new List<int>();
            int[] lesser = nums1.Length <= nums2.Length ? nums1 : nums2;
            int[] larger = lesser == nums1 ? nums2 : nums1;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < lesser.Length; i++)
            {
                if (!dict.ContainsKey(lesser[i]))
                {
                    dict.Add(lesser[i], 1);
                }
                else
                {
                    dict[lesser[i]] += 1;                    
                }
            }
            for (int i = 0; i < larger.Length; i++)
            {
                if (dict.ContainsKey(larger[i]))
                {
                    output.Add(larger[i]);
                    dict[larger[i]]--;
                    if (dict[larger[i]] == 0)
                    {
                        dict.Remove(larger[i]);
                    }
                }
            }

            return output.ToArray();
        }

        #endregion

        #region T367 不使用库函数，问一个正整数是否是完全平方数
        //二分法
        public bool IsPerfectSquare(int num)
        {
            int start = 1, end = num / 2;
            int mid;
            double div;
            while (end - start > 1)
            {
                mid = (start + end) / 2;
                div = (double)num / (double)mid;    //防止整数类型溢出
                if (div == mid) return true;
                else if (div < mid)
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }
            }
            if ((double)num / (double)start == start || (double)num / (double)end == end) return true;
            return false;
        }

        #endregion

        #region T371 两个整数相加，不使用+和-符号

        public int GetSum(int a, int b)
        {            
            if (b == 0)
            {
                return a;
            }
            int sum = a ^ b;    //异或实现了不带进位的加法
            int carry = (a & b) << 1;   //与运算向左移动一位的结果指出了哪些位上要进位
            return GetSum(sum, carry);    //不带进位的加法结果加上进位。由于加法之后又可能有进位，所以递归调用，直到没有进位
        }

        #endregion

        #region T374 猜数字大小

        public int guessNumber(int n)
        {
            int low = 1, high = n, mid = 0;
            while (low < high)
            {
                mid = low + (high - low) / 2;    //防止整型溢出
                if (mid == low)
                {
                    low += 1;
                    break;
                }
                int res = guess(mid);
                if (res == 0)
                {
                    return mid;
                }
                else if (res == -1)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
            if (guess(low) == 0) return low;
            return high;
        }

        private int guess(int num)
        {
            int ans = 6;
            if (num == ans) return 0;
            else if (ans < num) return -1;
            else return 1;
        }

        #endregion
    }
}
