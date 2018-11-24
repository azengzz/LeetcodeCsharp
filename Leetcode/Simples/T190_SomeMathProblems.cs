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

        #region T196 House Robber

        public int Rob(int[] nums)
        {
            int currentMax = 0;    //当前最大值
            int lastMax = 0;    //上次最大值

            if (nums.Length <= 1) return nums.Length == 0 ? 0 : nums[0];

            currentMax = nums[0] > nums[1] ? nums[0] : nums[1];
            lastMax = nums[0];
            for (int i = 2; i < nums.Length; i++)
            {
                int tmp = currentMax;
                int now = nums[i] + lastMax;
                currentMax = now > currentMax ? now : currentMax;
                lastMax = tmp;
            }

            return currentMax;
        }

        #endregion

        #region T202 快乐数

        public bool IsHappy(int n)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            while (n != 1)
            {
                if (dict.ContainsKey(n))
                    return false;
                dict.Add(n, 1);
                int ans = 0;
                int remaind = 0;
                while (n != 0)
                {
                    remaind = n % 10;
                    n /= 10;
                    ans += remaind * remaind;
                }
                n = ans;
            }

            return true;
        }

        #endregion

        #region T203 移出链表元素

        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode ptr = head;

            while (ptr != null)
            {
                if (head.val == val)
                {
                    head = head.next;
                    ptr = head;
                    continue;
                }
                if (ptr.next != null && ptr.next.val == val)
                {
                    ptr.next = ptr.next.next;
                }
                else
                {
                    ptr = ptr.next;
                }                
            }
            return head;
        }

        #endregion

        #region T204 计数质数

        public int CountPrimes(int n)
        {
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                int j, tmp = 0;
                for (j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        tmp += 1;
                        break;
                    }
                }
                if (tmp == 0) count++;
            }
            return count;
        }

        #endregion

        #region T205 同构字符串

        public bool IsIsomorphic(string s, string t)
        {
            if (s == null || t == null) return false;
            if (s.Length != t.Length) return false;

            Dictionary<char, char> charsDict = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (charsDict.ContainsKey(s[i]))
                {
                    char existedVal = charsDict[s[i]];
                    if (t[i] != existedVal)
                        return false;
                }
                else if (charsDict.ContainsValue(t[i]))
                {
                    var collect = from d in charsDict where d.Value == t[i] select d.Key;
                    char existtedKey = collect.ToList<char>()[0];
                    if (existtedKey != s[i])
                        return false;
                }
                else
                {
                    charsDict.Add(s[i], t[i]);
                }

            }
            return true;
        }

        #endregion

        #region T206 反转链表

        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return head;

            ListNode ptrA = null;
            ListNode ptrB = head;

            while (head.next != null)
            {
                ptrB = head;
                head = head.next;
                ptrB.next = ptrA;
                ptrA = ptrB;
            }
            head.next = ptrB;
            return head;
        }

        #endregion
    }
}
