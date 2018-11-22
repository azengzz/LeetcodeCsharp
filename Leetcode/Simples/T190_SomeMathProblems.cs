using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T190_SomeMathProblems
    {
        public T190_SomeMathProblems()
        {
        }

        #region T190 颠倒二进制位。 把一个32位无符号整型数的二进制形式颠倒后输出其十进制值

        public uint reverseBits(uint n)
        {
            Queue<uint> queue = new Queue<uint>();
            queue.Enqueue(0);
            uint val = 0;
            uint bitsCount = 0;
            //注意如果二进制表示不够32位的，要在前面补够0
            //一边入队一边出队，一边除2取余，一边算结果
            do
            {
                val *= 2;
                val += queue.Dequeue();
                if (n > 0)
                {
                    queue.Enqueue(n % 2);
                    n /= 2;
                }
                else if (bitsCount < 32)
                {
                    queue.Enqueue(0);
                }
                ++bitsCount;
            } while (queue.Count > 0);
            return val;
        }

        /* ---------------------------------------------------------
         * 看到提交里有人用纯粹的位计算。看起来确实快！
             public class Solution {
                public uint reverseBits(uint n) {
                    if (n == 0) return 0;
                    uint res = 0;
                    for (int i = 0; i < 32; i++)
                    {
                        res <<= 1;
                        if ((n & 1) == 1) res++;
                        n >>= 1;
                    }
                    return res;
                }
             }
         */

        #endregion

        #region T191 求一个无符号整数的二进制表达式中有多少个1

        public int HammingWeight(uint n)
        {
            if (n == 0) return 0;

            uint count = 0;
            for (int i = 0; i < 32; i++)
            {
                count += n & 1;
                n >>= 1;
            }
            return (int)count;
        }

        #endregion
    }
}
