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

        #region T217 判断数组是否存在重复元素

        public bool ContainsDuplicate(int[] nums)
        {
            //先排序的做法------------------------------------------------
            //if (nums == null || nums.Length == 0) return false;

            //Array.Sort(nums);
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    if (nums[i] == nums[i + 1]) return true;
            //}
            //return false;

            //使用字典-------------------------------------------------
            if (nums == null || nums.Length == 0) return false;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 1);
                }
                else return true;
            }
            return false;
        }

        #endregion

        #region T219 判断数组中是否存在重复元素，且它们下标绝对值之差最大为K

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            //注意是“索引的绝对值之差”
            if (nums == null || nums.Length < 2) return false;

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], new List<int> { i });
                }
                else
                {
                    if (true == diff(dict[nums[i]], i, k)) return true;
                    dict[nums[i]].Add(i);
                }
            }
            return false;
        }

        private bool diff(List<int> list, int newVal, int expect)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((newVal - list[i] <= expect) 
                || (list[i] - newVal >= expect * (-1))) return true; 
            }
            return false;
        }

        #endregion

        #region T231 2的幂次方

        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0) return false;

            while (n > 1)
            {
                if (n % 2 != 0) return false;
                n /= 2;
            }
            return true;
        }

        //优秀的解答
        //public bool IsPowerOfTwo(int n)
        //{
        //    if (n <= 0) return false;

        //    if ((n & n - 1) == 0) return true;
        //    return false;
        //}

        #endregion

        #region T234 回文链表   
             
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return true;
            if (head.next.next == null)
            {
                if (head.val == head.next.val) return true;
                return false;
            }
            if (head.next.next.next == null)
            {
                if (head.val == head.next.next.val) return true;
                return false;
            }

            ListNode fast = head, slow = head;
            while (fast.next != null)  //当快指针走完时，慢指针走到链表中间位置
            {
                fast = fast.next;    //先走一步
                if (fast.next != null)
                {
                    fast = fast.next;
                    slow = slow.next;
                }                
            }

            ListNode reverseHead = slow.next;
            reverseHead = ReverseList(reverseHead);    //t206题反转链表
            ListNode reverse = reverseHead;

            fast = head;
            bool flag = true;
            while (reverse != null)    //比较
            {
                if (fast.val != reverse.val)
                {
                    flag = false;
                    break;
                }
                fast = fast.next;
                reverse = reverse.next;
            }
            slow.next = ReverseList(reverseHead);    //再翻转回来

            return flag;
        }

        #endregion


    }
}
