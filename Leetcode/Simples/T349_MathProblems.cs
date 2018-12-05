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

        #region T383 赎金信。 问ransomNote字符串是否全都属于magazine字符串（字符数量也要一致）。假设只包含小写字母

        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            CreateDictionary(dict, magazine);

            Dictionary<char, int> dict2 = new Dictionary<char, int>();
            CreateDictionary(dict2, ransomNote);

            foreach (var c in dict2)
            {
                if (!dict.ContainsKey(c.Key) || c.Value > dict[c.Key])
                    return false;
            }

            return true;
        }

        private void CreateDictionary(Dictionary<char, int> dict, string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                {
                    dict[str[i]]++;
                }
                else
                {
                    dict.Add(str[i], 1);
                }
            }
        }

        #endregion

        #region T387 给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回-1。假设只包含小写字母

        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            var colle = from d in dict where d.Value == 1 select d.Key;
            char[] singles = colle.ToArray();
            if (singles.Length > 0)
            {
                return s.IndexOf(singles[0]);
            }
            return -1;
        }

        #endregion

        #region T389 找出两个字符串中不同的那个字母。其中t字符串包含了s字符串的所有字符，且随机重排，并有一个新元素，求那个新元素

        //利用异或的特性：相同为0，相异为1，最后s和t中相同的字符异或之后为0了，剩下的就是不同的字符
        public char FindTheDifference(string s, string t)
        {
            if (s == "") return t[0];

            int res = s[0];
            for(int i = 1; i < s.Length; i++)
            {
                res ^= s[i];
            }
            for (int i = 0; i < t.Length; i++)
            {
                res ^= t[i];
            }
            return (char)res;
        }

        #endregion

        #region T400 在无限的整数序列中找到第n个数字

        public int FindNthDigit(int n)
        {
            int val = n;
            int level = 0;
            while (level < 8)
            {
                int temp = 9 * (int)Math.Pow(10, level) * (level + 1);
                if (temp >= val) break;
                else val -= temp;
                level++;
            }

            if (level >= 8)    //在10的8次方这个范围内的数字个数已超过整型的表达范围
            {
                //do nothing
            }

            int result = val / (level + 1);
            int remaind = val % (level + 1);
            result = result + (int)Math.Pow(10, level) - 1;
            if (remaind > 0)
            {
                result += 1;
                result /= (int)Math.Pow(10, level + 1 - remaind);
            } 
            return result % 10;
        }

        #endregion

        #region T401 二进制手表。非负整数n代表LED亮着的数量，要求返回所有可能的时间组合

        public List<int> CreateNOnes(int totalBits, int numOfOne)
        {
            if (numOfOne == 0) return new List<int> { 0 };

            if (numOfOne == 1)
            {
                List<int> compare = new List<int>();
                for (int i = 0; i < totalBits; i++)
                {
                    compare.Add(0x01 << i);
                }
                return compare;
            }

            List<int> lastList = CreateNOnes(totalBits, numOfOne - 1);
            List<int> res = new List<int>();
            for (int i = 0; i < totalBits; i++)
            {
                int num = 0x01 << i;
                for (int j = 0; j < lastList.Count; j++)
                {
                    int tmp = num | lastList[j];
                    if (!lastList.Contains(tmp) && !res.Contains(tmp))
                    {
                        res.Add(tmp);
                    }
                }
            }
            return res;
        }

        public IList<string> ReadBinaryWatch(int num)
        {
            const int MAX_HOUR_LEDS = 3;
            const int MAX_SEC_LEDS = 5;

            List<string> res = new List<string>();

            for (int hourNum = 0; hourNum <= MAX_HOUR_LEDS; hourNum++)
            {
                if (num - hourNum < 0) break;
                if (num - hourNum > MAX_SEC_LEDS) continue;
                List<int> hoursColle = CreateNOnes(4, hourNum);
                List<int> secsColle = CreateNOnes(6, num - hourNum);

                foreach(var hour in hoursColle)
                {
                    if (hour > 11) continue;
                    foreach(var sec in secsColle)
                    {
                        if (sec > 59) continue;
                        string secStr = sec < 10 ? "0" + sec.ToString() : sec.ToString();
                        res.Add(hour.ToString() + ":" + secStr);
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
