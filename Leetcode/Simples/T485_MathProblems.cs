using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
