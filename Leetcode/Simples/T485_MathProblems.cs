using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T485_MathProblems
    {
        public T485_MathProblems() { }

        #region T485 给定一个二进制数组，计算其中最大了连续1的个数

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0, res = 0;
            for (int i = 0; i <= nums.Length; i++)
            {
                if (i == nums.Length || nums[i] == 0)
                {
                    if (count > res) res = count;
                    count = 0;
                }
                else
                    count++;
            }
            return res;
        }

        #endregion

        #region T492 构造矩形

        public int[] ConstructRectangle(int area)
        {
            int length = (int)Math.Sqrt(area);
            while (area % length != 0)
            {
                length++;
            }
            int width = area / length;
            return new int[] { length, width };
        }

        #endregion

        #region T496 寻找下一个更大的元素

        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            //遍历nums，栈为空时将当前元素入栈；栈不空时，若当前元素大于栈顶，则出栈，将出栈值与当前元素构成键值对
            Stack<int> stk = new Stack<int>();
            Dictionary<int, int> nextLargerDict = new Dictionary<int, int>();
            int j = 0;
            for (j = 0; j < nums.Length; j++)
            {
                while (stk.Count > 0 && nums[j] > stk.Peek())
                {
                    nextLargerDict.Add(stk.Pop(), nums[j]);
                }                 
                stk.Push(nums[j]);
            }

            int[] res = new int[findNums.Length];
            for (int ii = 0; ii < findNums.Length; ii++)
            {
                if (nextLargerDict.ContainsKey(findNums[ii]))
                    res[ii] = nextLargerDict[findNums[ii]];
                else
                    res[ii] = -1;
            }
            return res;
        }

        #endregion

        #region T500 判断单词是否在键盘上的同一行

        public string[] FindWords(string[] words)
        {
            List<string> list = new List<string> { "qwertyuiop", "asdfghjkl", "zxcvbnm" };
            List<string> res = new List<string>();
            foreach (string w in words)
            {
                List<char> tmp = w.ToLower().ToList<char>();

                var colle = from li in list where tmp.All(c => li.Contains(c)) select w;
                if (colle.ToArray().Length > 0)
                    res.Add(w);
                
            }
            return res.ToArray();
        }

        #endregion

        #region T501 二叉搜索树中的众数        

        public int[] FindMode(TreeNode root)
        {
            int currentCount = 0;
            int maxCount = 0;
            int lastPriorVal = 0;
            List<int> res = new List<int>();

            InOrderTraversal(root, ref currentCount, ref maxCount, ref lastPriorVal, res);
            return res.ToArray();
            
        }

        private void InOrderTraversal(TreeNode root, ref int currentCount, ref int maxCount, ref int lastPriorVal, List<int> res)
        {
            if (root == null) return ;           

            InOrderTraversal(root.left, ref currentCount, ref maxCount, ref lastPriorVal, res);
            currentCount++;
            if (lastPriorVal != root.val)
            {
                lastPriorVal = root.val;
                currentCount = 1;
            }
          
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                res.Clear();
                res.Add(root.val);
            }
            else if (currentCount == maxCount)
            {
                res.Add(root.val);
            }
            InOrderTraversal(root.right, ref currentCount, ref maxCount, ref lastPriorVal, res);
        }

        #endregion

        #region T504 七进制数

        public string ConvertToBase7(int num)
        {
            Stack<int> remainds = new Stack<int>();
            bool isNagative = false;
            if (num < 0)
            {
                num *= -1;
                isNagative = true;
            }
            while (num > 0)
            {
                remainds.Push(num % 7);
                num /= 7;
            }

            int res = 0;
            while (remainds.Count > 0)
            {
                res *= 10;
                res += remainds.Pop();
            }
            string resstr = isNagative == true ? "-" + res.ToString() : res.ToString();
            return resstr;
        }

        #endregion

        #region T506 相对名次

        public string[] FindRelativeRanks(int[] nums)
        {
            int[] tmp = new int[nums.Length];
            nums.CopyTo(tmp, 0);

            Array.Sort(tmp);

            int rank = 1;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = tmp.Length - 1; i >= 0; i--)
            {
                dict.Add(tmp[i], rank++);
            }

            List<string> res = new List<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                int r = dict[nums[i]];
                if (r == 1) res.Add("Gold Medal");
                else if (r == 2) res.Add("Silver Medal");
                else if (r == 3) res.Add("Bronze Medal");
                else res.Add(r.ToString());
            }

            return res.ToArray();
        }

        #endregion

        #region T507 完美数

        public bool CheckPerfectNumber(int num)
        {
            if (num <= 1) return false;

            List<int> factors = new List<int> { 1 };

            int f = (int)Math.Sqrt(num);
            while (f > 1)    //寻找所有因子
            {
                if (num % f == 0)
                {
                    factors.Add(f);
                    factors.Add(num / f);
                }
                f--;
            }
            return num == factors.Sum();
        }

        #endregion

        #region T520 检测大写字母

        public bool DetectCapitalUse(string word)
        {
            if (word.ToUpper() == word || word.ToLower() == word)    //检测全大写或全小写
            {
                return true;
            }
            else
            {
                string firstChar = word.Substring(0, 1);
                string restChars = word.Substring(1, word.Length - 1);
                if (firstChar.ToUpper() == firstChar && restChars.ToLower() == restChars) return true;
                return false;
            }
        }

        #endregion

        #region T530 二叉搜索树的最小绝对差

        private class MinDiffInfo
        {
            public int CurrentDiff { get; set; }
            public int MinDff { get; set; }
            public int LastVal { get; set; }

            public MinDiffInfo()
            {
                CurrentDiff = 0;
                MinDff = int.MaxValue;
                LastVal = int.MaxValue;
            }
        }

        public int GetMinimumDifference(TreeNode root)
        {
            MinDiffInfo mdi = new MinDiffInfo();
            GetMin(root, mdi);
            return mdi.MinDff;
        }

        private void GetMin(TreeNode root, MinDiffInfo mdi)
        {
            if (root == null) return;

            GetMin(root.left, mdi);

            mdi.CurrentDiff = root.val - mdi.LastVal;
            if (mdi.CurrentDiff < 0) mdi.CurrentDiff *= -1;
            if (mdi.CurrentDiff < mdi.MinDff) mdi.MinDff = mdi.CurrentDiff;
            mdi.LastVal = root.val;

            GetMin(root.right, mdi);
        }

        #endregion

        #region T532 寻找数组中的K-Diff数对

        public int FindPairs(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int res = 0;
            foreach (int n in nums)    //数组中各数字出现的次数做成表
            {
                if (dict.ContainsKey(n)) dict[n]++;
                else dict.Add(n, 1);
            }
            foreach (int n in nums)
            {
                if (k == 0)
                {
                    if (dict[n] > 1)
                        res++;
                }
                else
                {
                    if (dict[n] == 0) continue;
                    if (dict.ContainsKey(n - k))
                    {
                        if (dict[n - k] > 0) res++;
                    }
                    if (dict.ContainsKey(n + k))
                    {
                        if (dict[n + k] > 0) res++;
                    }
                }
                dict[n] = 0;    //这个数已经找完了，不要再找它
            }

            return res;
        }

        #endregion

        #region T538 把二叉搜索树转换为累加树

        public TreeNode ConvertBST(TreeNode root)
        {
            int sum = 0;

            ConvertTree(root, ref sum);
            return root;
        }

        private void ConvertTree(TreeNode root, ref int sum)
        {
            if (root == null) return;

            ConvertTree(root.right, ref sum);
            root.val += sum;
            sum = root.val;
            ConvertTree(root.left, ref sum);
        }

        #endregion

        #region T541 反转字符串：每隔K个字符翻转K个字符

        public string ReverseStr(string s, int k)
        {
            if (k <= 1) return s;

            StringBuilder sb = new StringBuilder();
            int nums2K = s.Length / (2 * k);

            for (int i = 0; i < nums2K; i++)
            {
                char[] rev = new char[k];
                char[] norm = new char[k];
                int rev_end = (i * 2 + 1) * k;
                for (int j = 0; j < k; j++)
                {
                    rev[j] = s[rev_end - 1 - j];
                    norm[j] = s[rev_end + j];
                }
                sb.Append(rev);
                sb.Append(norm);
            }

            int rest = s.Length - nums2K * 2 * k;
            if (rest > k)
            {
                char[] temp = new char[k];
                int rev_end = (nums2K * 2 + 1) * k;
                for (int j = 0; j < k; j++)
                {
                    temp[j] = s[rev_end - 1 - j];
                }
                sb.Append(temp);
                temp = new char[rest - k];
                for (int j = 0; j < rest - k; j++)
                {
                    temp[j] = s[rev_end + j];
                }
                sb.Append(temp);
            }
            else
            {
                char[] temp = new char[rest];
                for (int j = 0; j < rest; j++)
                {
                    temp[j] = s[s.Length - 1 - j];
                }
                sb.Append(temp);
            }
            return sb.ToString();
        }

        #endregion

        #region T543 二叉树的直径

        public int DiameterOfBinaryTree(TreeNode root)
        {
            int diameter = 0;
            GetDiameter(root, ref diameter);
            return diameter;
        }

        private int GetDiameter(TreeNode node, ref int diameter)
        {
            if (node == null) return 0;

            
            int leftHeight = GetDiameter(node.left, ref diameter);
            int rightHeight = GetDiameter(node.right, ref diameter);
            if (diameter < leftHeight + rightHeight)
                diameter = leftHeight + rightHeight;

            return (leftHeight >= rightHeight ? leftHeight : rightHeight) + 1;
        }

        #endregion

        #region T551 学生出勤记录

        public bool CheckRecord(string s)
        {
            return (Regex.Matches(s, @"A").Count < 2 && !Regex.IsMatch(s, @"LLL"));
        }

        #endregion

        #region T557 翻转字符串中的单词

        public string ReverseWords(string s)
        {
            string[] ss = s.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (string str in ss)
            {
                if (str == "") continue;
                sb.Append(str.ToCharArray().Reverse().ToArray());
                sb.Append(" ");
            }
            if(sb.Length != 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        #endregion

        #region T561 数组拆分

        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int maxMinGroupSum = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                maxMinGroupSum += nums[i];
            }
            return maxMinGroupSum;
        }

        #endregion
    }
}
