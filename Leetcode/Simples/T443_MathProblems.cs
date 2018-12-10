using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
