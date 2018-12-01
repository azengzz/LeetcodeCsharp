using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T235_DataStructures
    {
        #region T235 二叉搜索树的最近公共祖先

        //使用二叉搜索树的特征进行查找。如果要找的2个值都比根节点小，就在左子树找；
        //如果要找的2个节点都比根节点大，则在右子树找；
        //如果2个值在根节点两侧，或者有一个值等于根节点，则最近公共节点就是此根节点
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode bigNode = p.val > q.val ? p : q;
            TreeNode smallNode = bigNode == p ? q : p;

            if (root.val > bigNode.val)
                return LowestCommonAncestor(root.left, p, q);
            else if (root.val < smallNode.val)
                return LowestCommonAncestor(root.right, p, q);
            else
                return root;

        }

        #endregion

        #region T237 只给定链表中的某个节点（非最后一个节点），调用这个方法删除它

        //已经知道node不是最后一个节点，所以可以这么做。把node节点的下个节点的值取来，然后删掉下个节点
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        #endregion

        #region T242 判断一个字符串t是否是另一个字符串s的字母异位词

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 1);
                }
                else
                {
                    dict[s[i]]++;
                }
                if (!dict.ContainsKey(t[i]))
                {
                    dict.Add(t[i], -1);
                }
                else
                {
                    dict[t[i]]--;
                }
            }
            var colle = from d in dict where d.Value != 0 select d.Key;
            if (colle.ToList<char>().Count != 0) return false;
            return true;
        }

        #endregion

        #region T257 二叉树的所有路径

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> result = new List<string>();
            List<TreeNode> popedNodes = new List<TreeNode>();
            Stack<TreeNode> stk = new Stack<TreeNode>();

            if (root == null) return result;

            stk.Push(root);
            while (stk.Count != 0)    //深度优先搜索
            {
                TreeNode node = stk.Pop();
                popedNodes.Add(node);    //出栈的节点放入链表中
                if (node.left == null && node.right == null)
                {
                    result.Add(CreateString(popedNodes));
                    popedNodes.RemoveAt(popedNodes.Count - 1);
                }
                if (node.right != null) stk.Push(node.right);    //先右孩子入栈
                if (node.left != null) stk.Push(node.left);    //再左孩子入栈

                //如果链表最后一个节点的左右孩子都不在栈中了，说明它的左右孩子都已访问过，它自己也被访问过，那就可从链表中删掉了
                while (popedNodes.Count > 0 && !stk.Contains(popedNodes[popedNodes.Count-1].left) && !stk.Contains(popedNodes[popedNodes.Count - 1].right))
                {
                    popedNodes.RemoveAt(popedNodes.Count - 1);
                }
                
            }
            return result;
        }

        private string CreateString(List<TreeNode> popedNodes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < popedNodes.Count - 1; i++)
            {
                sb.Append(popedNodes[i].val.ToString() + "->");
            }
            sb.Append(popedNodes[popedNodes.Count - 1].val.ToString());
            return sb.ToString();
        }

        #endregion

        #region T263 判断是否丑数

        public bool IsUgly(int num)
        {
            if (num < 1) return false;

            while (num > 5)    //1~5都是丑数
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                    continue;
                }
                if (num % 3 == 0)
                {
                    num = num / 3;
                    continue;
                }
                if (num % 5 == 0)
                {
                    num = num / 5;
                    continue;
                }
                return false;
            }

            return true;
        }

        #endregion

        #region T268 一个序列从0开始，0,1,2,....,n，共n个数，问其中缺失的数字是多少

        public int MissingNumber(int[] nums)
        {
            int len = nums.Length;
            int expectSum = len * (len + 1) / 2;
            int serialSum = 0;
            for (int i = 0; i < len; i++)
            {
                serialSum += nums[i];
            }
            return expectSum - serialSum;
        }

        #endregion

        #region T278 第一个错误的版本

        public int FirstBadVersion(int n)
        {
            int factor = 0;
            if (n > int.MaxValue / 2)
            {
                if (IsBadVersion(int.MaxValue / 2) == false)
                {
                    factor = int.MaxValue / 2;
                    n -= factor;
                }
            }

            int begin = 1, end = n;
            int mid = 0;
            bool isBad = false;
            while (begin < end)
            {
                mid = (begin + end) / 2;
                isBad = IsBadVersion(mid + factor);
                if (isBad == true)
                {
                    end = mid;
                }
                else
                {
                    if (end - mid == 1) return end + factor;
                    begin = mid;
                }
            }
            return begin + factor;
        }

        //这是个API，这里就假设版本号4之后的都是出错的版本
        bool IsBadVersion(int version)
        {
            return version >= 1702766719;
        }

        //------看看别人的做法。如何避免溢出的
        //public class Solution : VersionControl
        //{
        //    public int FirstBadVersion(int n)
        //    {
        //        return getBadVersion(0, n);
        //    }

        //    private int getBadVersion(int start, int end)
        //    {
        //        if (start == end)
        //        {
        //            return start;
        //        }
        //        int mid = start + (end - start) / 2;
        //        return IsBadVersion(mid) ? getBadVersion(start, mid) : getBadVersion(mid + 1, end);
        //    }
        //}

        //--------非递归版本
        //public int FirstBadVersion(int n)
        //{
        //    int left = 0;
        //    int right = n;
        //    int mid = 0;
        //    while (left != right)
        //    {
        //        mid = left + (right - left) / 2;
        //        if (IsBadVersion(mid))
        //        {
        //            right = mid;
        //        }
        //        else
        //        {
        //            left = mid + 1;
        //        }
        //    }
        //    return left;
        //}

        #endregion

        #region T283 移动数组中的零到尾部，但保持非零数字的相对顺序。要求不适用额外空间实现，尽量少次数

        public void MoveZeroes(int[] nums)
        {
            int slow = 0, fast = 0;
            while (fast < nums.Length - 1)
            {
                ++fast;
                if (nums[fast] == 0) continue;
                if (nums[slow] != 0)
                {
                    ++slow;
                }
                if (fast > slow)
                {
                    nums[slow] = nums[fast];
                }
            }

            slow++;
            while (slow < nums.Length)
            {
                if (nums[slow] != 0) nums[slow] = 0;
                slow++;
            }
        }

        #endregion

        #region T290 判断给定的字符串是否复合给定的模式

        public bool WordPattern(string pattern, string str)
        {        
            string[] words = str.Split(' ');

            if (pattern.Length != words.Length) return false;

            Dictionary<char, string> dict = new Dictionary<char, string>();    //pattern每个字符和words每个词作为一对
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!dict.ContainsKey(pattern[i]))
                {
                    if (dict.ContainsValue(words[i])) return false;
                    dict.Add(pattern[i], words[i]);
                }
                else
                {
                    if (dict[pattern[i]] != words[i]) return false;
                }
            }
            return true;
        }

        #endregion

        #region T292 Nim游戏
        //你和你的朋友，两个人一起玩 Nim游戏：桌子上有一堆石头，每次你们轮流拿掉 1 - 3 块石头。 拿掉最后一块石头的人就是获胜者。你作为先手。
        //你们是聪明人，每一步都是最优解。 编写一个函数，来判断你是否可以在给定石头数量的情况下赢得游戏。
        public bool CanWinNim(int n)
        {
            return (n % 4 != 0);
        }

        #endregion

        #region T303 定义一个类及类方法SumRange，它用来计算数组索引范围i到j的累加和（i <= j）。且SumRange方法会多次调用
        //难点在于，直接累加的方式，遇到巨量的数据和巨多次的函数调用时，时间会超出限制
        public class NumArray
        {
            private int[] sums;

            public NumArray(int[] nums)
            {
                sums = new int[nums.Length];
                if (nums.Length == 0) return;
                sums[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    sums[i] = sums[i - 1] + nums[i];
                }
            }

            public int SumRange(int i, int j)
            {
                if (i == 0) return sums[j];
                else return sums[j] - sums[i - 1];
            }
        }

        #endregion

        #region T326 问一个数是否是3的幂次方。不使用循环和递归来计算。

        public bool IsPowerOfThree(int n)
        {
            return (n > 0 && (int)(Math.Log10(n) / Math.Log10(3)) - Math.Log10(n) / Math.Log10(3) == 0);
        }

        #endregion

        #region T342 问一个数是不是4的幂次方。不使用循环或递归来计算

        public bool IsPowerOfFour(int num)
        {
            if (num < 1) return false;
            return ((num & (num - 1)) == 0 && (0x55555555 & num) != 0);            
        }

        #endregion

        #region T344 反转字符串 （首尾颠倒）

        public string ReverseString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        #endregion

        #region T345 反转字符串中的元音字母

        public string ReverseVowels(string s)
        {
            char[] cs = s.ToCharArray();
            int front = 0, rear = cs.Length - 1;

            while (front < rear)
            {
                if (IsVowels(cs[front]) && IsVowels(cs[rear]))
                {
                    if (cs[front] != cs[rear])
                    {
                        cs[front] += cs[rear];
                        cs[rear] = (char)(cs[front] - cs[rear]);
                        cs[front] = (char)(cs[front] - cs[rear]);
                    }
                    front++;
                    rear--;
                    continue;
                }
                if (!IsVowels(cs[front]))
                {
                    front++;
                }
                if (!IsVowels(cs[rear]))
                {
                    rear--;
                }
            }
            return new string(cs);
        }

        private bool IsVowels(char v)
        {
            if (v >= 'a' && v <= 'z')
            {
                return (v == 'a' || v == 'e' || v == 'i' || v == 'o' || v == 'u');
            }
            return (v == 'A' || v == 'E' || v == 'I' || v == 'O' || v == 'U');
        }

        #endregion
    }
}
