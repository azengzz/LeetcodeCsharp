using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T404_MathProblems
    {
        public T404_MathProblems()
        {
        }

        #region T404 计算给定二叉树的所有左叶子之和
        //广度优先搜索
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;

            int res = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null)
                {
                    if (node.left.left == null && node.left.right == null)
                        res += node.left.val;
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            return res;
        }

        #endregion

        #region T405 数字转换为十六进制数

        public string ToHex(int num)
        {
            string[] hexStr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            uint mask = 0xF0000000;
            string res = "";
            for (int i = 0; i < 32; i += 4)
            {
                uint val = (uint)num & (mask >> i);
                val = val >> (28 - i);
                if (res == "" && val == 0) continue;
                res += hexStr[val];
            }
            return res != "" ? res : "0";
        }

        #endregion

        #region T409 求由一个包含大写字母和小写字母组成的字符串可以构造的最长回文串的长度
        //可否用linq更简单的实现？
        public int LongestPalindrome(string s)
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

            int len = 0;
            var colle = from odds in dict where odds.Value % 2 != 0 select odds.Value;
            var oddsArray = colle.ToArray();
            if (oddsArray.Length > 0)
            {
                len += oddsArray.Sum() - oddsArray.Length + 1;    //所有奇数个的字符各丢弃一个，但是最大奇数的那个字符不用丢弃
            }

            colle = from evens in dict where evens.Value % 2 == 0 select evens.Value;
            var evensArray = colle.ToArray();
            len += evensArray.Length > 0 ? colle.ToArray().Sum() : 0;
            return len;
        }

        #endregion

        #region T412 Fizz Buzz，输出从数字1到n的字符串表示，如果是3的倍数，输出"Fizz"；是5的倍数，输出"Buzz"，同时是3和5的倍数，输出"FizzBuzz"

        public IList<string> FizzBuzz(int n)
        {
            List<string> res = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                {
                    res.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    res.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    res.Add("Buzz");
                }
                else
                {
                    res.Add(i.ToString());
                }
            }
            return res;
        }

        #endregion

        #region T414 求一个非空数组中第三大的数。如果不存在，则返回最大数。要求时间复杂度O(n)
        //要求线性时间复杂度，所以不能使用先排序的算法
        public int ThirdMax(int[] nums)
        {
            List<int> top3 = new List<int> { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                if (top3.Contains(nums[i])) continue;

                if (nums[i] > top3[0])
                {
                    top3.Insert(0, nums[i]);
                    continue;
                }

                try
                {
                    if (nums[i] > top3[1])
                    {
                        top3.Insert(1, nums[i]);
                        continue;
                    }
                }catch(ArgumentOutOfRangeException)
                {
                    top3.Add(nums[i]);
                    continue;
                }

                try
                {
                    if (nums[i] > top3[2])
                    {
                        top3.Insert(2, nums[i]);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    top3.Add(nums[i]);
                    continue;
                }              
            }
            return top3.Count >= 3 ? top3[2] : top3[0];
        }

        #endregion

        #region T415 两个代表数字的字符串相加。不准使用库将字符串直接转换为数字

        public string AddStrings(string num1, string num2)
        {
            Stack<char> stk = new Stack<char>();
            int carry = 0;
            int index1 = num1.Length - 1, index2 = num2.Length - 1;

            while (index1 >= 0 && index2 >= 0)
            {
                UpdateStackAndCarry(stk, ref carry, (char)(num1[index1--] + num2[index2--] - '0' + carry));
            }
            while (index1 >= 0)
            {
                UpdateStackAndCarry(stk, ref carry, (char)(num1[index1--] + carry));
            }
            while (index2 >= 0)
            {
                UpdateStackAndCarry(stk, ref carry, (char)(num2[index2--] + carry));
            }

            if (carry == 1) stk.Push('1');

            StringBuilder sb = new StringBuilder();
            while(stk.Count > 0)
            {
                sb.Append(stk.Pop());
            }
            return sb.ToString();
        }

        private void UpdateStackAndCarry(Stack<char> stk, ref int carry, char c)
        {
            carry = c > '9' ? 1 : 0;
            c = c > '9' ? (char)(c - 10) : c;
            stk.Push(c);
        }

        #endregion

        #region T427 建立四叉树

        public QuadTreeNode Construct(int[][] grid)
        {
            int dimension = grid[0].Length;    //维度
            QuadTreeNode tree = null;

            tree = AddQuadTreeNode(grid, 0, 0, dimension);

            return tree;
        }

        private QuadTreeNode AddQuadTreeNode(int[][] grid, int row, int column, int dimension)
        {
            int firstVal = grid[row][column];
            for (int i = row; i < row + dimension; i++)
            {
                for (int j = column; j < column + dimension; j++)
                {
                    if (grid[i][j] != firstVal)
                    {
                        QuadTreeNode node = new QuadTreeNode(true, false, null, null, null, null);
                        node.topLeft =  AddQuadTreeNode(grid, row, column, dimension / 2);
                        node.topRight = AddQuadTreeNode(grid, row, column + dimension / 2, dimension / 2);
                        node.bottomLeft = AddQuadTreeNode(grid, row + dimension / 2, column, dimension / 2);
                        node.bottomRight = AddQuadTreeNode(grid, row + dimension / 2, column + dimension / 2, dimension / 2);
                        return node;
                    }
                }
            }
            return new QuadTreeNode(firstVal == 1, true, null, null, null, null);
        }

        #endregion

        #region T429 输出N察树的层序遍历结果
        //广度优先算法。每次出队列时，把出列节点的子节点添加进队列。只是这次的子节点是链表
        public IList<IList<int>> LevelOrder(NTreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            Queue<IList<NTreeNode>> queue = new Queue<IList<NTreeNode>>();
            List<IList<int>> res = new List<IList<int>>();

            queue.Enqueue(new List<NTreeNode> { root });
            while (queue.Count > 0)
            {
                IList<NTreeNode> nodesList = queue.Dequeue();
                IList<NTreeNode> childrenList = new List<NTreeNode>();
                List<int> addList = new List<int>();
                foreach (NTreeNode node in nodesList)
                {
                    addList.Add(node.val);
                    foreach (NTreeNode n in node.children)
                    {
                        childrenList.Add(n);
                    }
                }
                if (addList.Count > 0)
                    res.Add(addList);
                if (childrenList.Count > 0)
                    queue.Enqueue(childrenList);
            }
            return res;
        }

        #endregion

        #region T434 求字符串中的单词数。这里的单词指的是连续的不是空格的字符。且假设字符串中不包含不可打印字符

        public int CountSegments(string s)
        {
            string[] strs = s.Split(' ');
            int len = 0;
            foreach (string str in strs)
            {
                if (str == "" || str[0] == ' ') continue;
                len++;
            }
            return len;
        }

        #endregion

        #region T437 找出给定二叉树中路径之和等于给定数值的路径总数

        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;

            int count = 0;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);
            while (stk.Count > 0)
            {
                TreeNode node = stk.Pop();
                count += FindWith(node, sum);

                if (node.right != null) stk.Push(node.right);
                if (node.left != null) stk.Push(node.left);
            }
            return count;
        }

        private int FindWith(TreeNode node, int sum)
        {
            if (node == null) return 0;

            int count = 0;
            if (node.val == sum)
            {
                count++;
            }
            count += FindWith(node.left, sum - node.val);
            count += FindWith(node.right, sum - node.val);
            return count;
        }

        #endregion
    }
}
