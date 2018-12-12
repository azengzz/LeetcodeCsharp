using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T443_MathProblems
    {
        public T443_MathProblems()
        { }

        #region T443 压缩字符串

        public int Compress(char[] chars)
        {
            if (chars.Length <= 1) return chars.Length;

            int compressPtr = 0, slowPtr = 0, fastPtr = 0;
            while (fastPtr < chars.Length)
            {
                fastPtr++;
                if (fastPtr >= chars.Length || chars[fastPtr] != chars[slowPtr])
                {
                    int diff = fastPtr - slowPtr;
                    if (diff > 1)
                    {
                        compressPtr = CompressAt(chars, compressPtr, chars[slowPtr], diff);
                    }
                    else
                    {
                        chars[compressPtr++] = chars[slowPtr];
                    }
                    slowPtr = fastPtr;
                }
            }
            return compressPtr;
        }

        private int CompressAt(char[] chars, int compressPtr, char ch, int diff)
        {
            chars[compressPtr++] = ch;
            if (diff < 10)
            {
                chars[compressPtr++] = (char)(diff + '0'); 
            }
            else
            {
                char[] numstr = diff.ToString().ToCharArray();
                foreach(char c in numstr)
                {
                    chars[compressPtr++] = c;
                }
            }
            return compressPtr;
        }

        #endregion

        #region T447 回旋镖的数量

        //思路：以每个点到起始点的距离为key，有多少个相同的距离为value。从N个相同的距离中选2个，有(n-1)n种选择法
        public int NumberOfBoomerangs(int[,] points)
        {
            if (points.Length < 6) return 0;

            int count = 0;
            for (int i = 0; i < points.Length/2; i++)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int j = 0; j < points.Length/2; j++)
                {
                    if (i == j) continue;

                    int distance = (points[i, 0] - points[j, 0]) * (points[i, 0] - points[j, 0]) +
                                    (points[i, 1] - points[j, 1]) * (points[i, 1] - points[j, 1]);
                    if (!dict.ContainsKey(distance))
                    {
                        dict.Add(distance, 1);
                    }
                    else
                    {
                        dict[distance]++;
                    }
                }
                foreach (var v in dict.Values)
                {
                    if (v >= 2)
                    {
                        count += (v - 1) * v;
                    }
                }
            }
            return count;           
        }

        #endregion

        #region T448 找到所有数组中消失的数字

        //先交换数组成员，使得数字按正向顺序排列，然后一次遍历找出所有值与下标对不上的元素的下标
        public IList<int> FindDisappearedNumbers(int[] nums)
        {           
            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] != nums[nums[i] - 1])
                {
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }                       
            }

            List<int> res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    res.Add(i + 1);
                }
            }
            return res;
        }

        #endregion

        #region T453 最小的移动次数使数组元素相等

        public int MinMoves(int[] nums)
        {
            if (nums.Length == 1) return 0;

            Array.Sort(nums);
            int sum = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                int largest = nums[nums.Length - 1 - i] + sum;
                int secondLargest = nums[nums.Length - 2 - i] + sum;
                int diff = largest - secondLargest;
                diff = i * diff;
                largest += diff;
                sum += largest - secondLargest;
            }
            return sum;
        }

        //进阶解法
        //public int MinMoves(int[] nums)
        //{
        //    var min = nums.Min();
        //    return nums.Sum(v => v - min);
        //}

        #endregion

        #region T455 分发饼干

        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);

            int indexG = 0, indexS = 0;
            int res = 0;

            while (indexG < g.Length && indexS < s.Length)
            {
                if (s[indexS] >= g[indexG])
                {
                    indexG++;
                    indexS++;
                    res++;
                }
                else
                {
                    indexS++;
                }
            }
            return res;
        }

        #endregion

        #region T458 可怜的猪

        /*
         * 以题中例子举例，有1000桶，15分钟死亡，有60分钟可以测试。
           如果只有1只猪，它可以在60分钟内测5桶：第0分钟喝1桶，15分钟喝第二桶，30分钟第三桶，45分钟第4桶。如果没死，则第五桶有毒。
           如果有2只猪，则可以测25桶。猪A负责行，猪B负责列，如下：
            1  2  3  4  5
            6  7  8  9 10
           11 12 13 14 15
           16 17 18 19 20
           21 22 23 24 25
           在第0分钟，猪A喝1，2，3，4，5桶，猪B喝1，6，11，16，21桶。如果15分钟的时候两只猪都死了，那么桶1有毒；如果只有猪A死了，
           那么2，3，4，5有毒，用猪B在剩下的45分钟里测，刚好符合时间要求。
           如果2只猪在第15分钟都没死，则猪A喝6，7，8，9，10桶，猪B喝2，7，12，17，22桶，然后看哪只猪死了。以此类推。
           所以如果有N只猪，它可以在15分钟死亡，60分钟测试的条件下测5的N次方个桶。
         */

        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            int maxTryTimes = minutesToTest / minutesToDie + 1;
            int pigs = 1;
            while (pigs < buckets)
            {
                if (Math.Pow(maxTryTimes, pigs) >= buckets)
                    return pigs;
                pigs++;
            }
            return 0;
        }

        #endregion

        #region T459 重复的子字符串
        //利用KMP算法求Next数组的思路。如果s确实由子串m构成，那么next的元素值应该在第一个子串结束之后从1，2，3，...一直增长
        public bool RepeatedSubstringPattern(string s)
        {
            int[] next = new int[s.Length + 1];
            int j = 0, k = -1;
            next[0] = -1;

            while (j < s.Length)
            {
                if (k == -1 || s[j] == s[k])
                {
                    next[++j] = ++k;
                }
                else
                {
                    k = next[k];
                }
            }

            return next[s.Length] > 0 && 
                   next[s.Length] % (s.Length - next[s.Length]) == 0;
        }

        #endregion

        #region T461 汉明距离：指的是两个整数对应的二进制位不同的数目

        public int HammingDistance(int x, int y)
        {
            int xor = x ^ y;
            int res = 0;
            for (int i = 0; i < 32; i++)
            {
                res += xor & 1;
                xor >>= 1;
            }
            return res;
        }

        #endregion

        #region T463 岛屿的周长

        public int IslandPerimeter(int[,] grid)
        {
            List<int> landBorders = new List<int>();
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (grid[x, y] == 0) continue;

                    int borders = 0;
                    if (y == 0 || grid[x, y - 1] == 0) ++borders;    //左边
                    if (x == 0 || grid[x - 1, y] == 0) ++borders;    //上边
                    if (y == cols - 1 || grid[x, y + 1] == 0) ++borders;    //右边
                    if (x == rows - 1 || grid[x + 1, y] == 0) ++borders;    //下边

                    if (borders != 0) landBorders.Add(borders);
                }              
            }

            int res = 0;
            foreach(int b in landBorders)
            {
                res += b;
            }
            return res;
        }

        #endregion

        #region T475 供暖器的最小加热半径

        public int FindRadius(int[] houses, int[] heaters)
        {
            //所有的房屋，只会分布在第一个供暖器的左边，或者最后一个供暖器的右边，或者某两个供暖器中间
            int maxRadius = 0;

            Array.Sort(heaters);

            for (int i = 0; i < houses.Length; i++)
            {
                int distance = 0;
                if (houses[i] < heaters[0])    //房子在第一个供暖器左边
                {
                    distance = heaters[0] - houses[i];                
                } 
                else if (houses[i] > heaters[heaters.Length - 1])    //在右边
                {
                    distance = houses[i] - heaters[heaters.Length - 1];
                }
                else    //在中间
                {
                    //找出房子在哪两个供暖器中间
                    int index = Array.BinarySearch(heaters, houses[i]);
                    if (index >= 0)    //房子刚好在某个供暖器的位置上
                    {
                        distance = 0;
                    }
                    else
                    {
                        index = ~index;    //看MSDN，二分查找函数返回值，如果没有命中，则返回第一个大于要查找值的元素的下标的字节反转值
                        int temp1 = heaters[index] - houses[i];
                        int temp2 = houses[i] - heaters[index - 1];
                        distance = temp1 < temp2 ? temp1 : temp2;    //取两个供暖器距离较小的那个
                    }
                }
                if (distance > maxRadius) maxRadius = distance;
            }
            return maxRadius;
        }

        #endregion

        #region T476 求数字的补数

        public int FindComplement(int num)
        {
            int preZeros = 0;
            while ((num & 0x80000000) == 0)
            {
                num <<= 1;
                preZeros++;
            }
            num = ~num;
            num >>= preZeros;
            return num;
        }

        #endregion

        #region T479 最大回文数的乘积

        public int LargestPalindrome(int n)
        {
            //参考网上的做法：构造2n位的回文数，然后看能否用两个n位的数乘积出来
            if (n == 1) return 9;

            int largest = (int)Math.Pow(10, n) - 1;
            int smallest = (int)Math.Pow(10, (n - 1));

            for (int num = largest; num >= smallest; num--)
            {
                long possible = num * (long)Math.Pow(10, n);
                int temp = num;
                int addup = 0;
                while (temp > 0)    //构造2n长度的回文
                {
                    addup = addup * 10;
                    addup += temp % 10;
                    temp /= 10;
                }
                possible += addup;
                for (long i = largest; i * i >= possible; i--)
                {
                    if (possible % i == 0)
                        return (int)(possible % 1337);
                }
            }

            return 0;
        }

        #endregion

        #region T482 密钥格式化

        /*
         给定一个密钥字符串S，只包含字母，数字以及 '-'（破折号）。N 个 '-' 将字符串分成了 N+1 组。给定一个数字 K，
         重新格式化字符串，除了第一个分组以外，每个分组要包含 K 个字符，第一个分组至少要包含 1 个字符。两个分组之间用 '-'（破折号）
         隔开，并且将所有的小写字母转换为大写字母。

         给定非空字符串 S 和数字 K，按照上面描述的规则进行格式化。
         */
        public string LicenseKeyFormatting(string S, int K)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = S.Length - 1; i >= 0; i--)
            {
                if (S[i] != '-')
                {
                    sb.Append(S[i]);
                    if (sb.Length % (K + 1) == K)
                        sb.Append('-');
                }
            }
            if (sb.Length > 0 && sb[sb.Length - 1] == '-')
                sb.Remove(sb.Length - 1, 1);
            string ss = new string(sb.ToString().ToUpper().Reverse().ToArray());
            return ss;
        }
        #endregion
    }
}
