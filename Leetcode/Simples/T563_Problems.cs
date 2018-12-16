using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T563_Problems
    {
        public T563_Problems() { }

        #region T563 求二叉树的坡度

        public int FindTilt(TreeNode root)
        {
            if (root == null) return 0;

            int tilt = 0;
            int leftSum = GetTreeSumAndTilt(root.left, ref tilt);
            int rightSum = GetTreeSumAndTilt(root.right, ref tilt);

            return Math.Abs(leftSum - rightSum) + tilt;
        }

        private int GetTreeSumAndTilt(TreeNode node, ref int tilt)
        {
            if (node == null) return 0;

            int leftSum = GetTreeSumAndTilt(node.left, ref tilt);
            int rightSum = GetTreeSumAndTilt(node.right, ref tilt);
            tilt += Math.Abs(leftSum - rightSum);
            return node.val + leftSum + rightSum;
        }

        #endregion

        #region T566 重塑二维矩阵

        public int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            if (r * c != nums.Length) return nums;

            int level1 = nums.GetLength(0);
            int level2 = nums.GetLength(1);
            int[,] res = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    int origin_i = (i * c + j) / level2;
                    int origin_j = i * c + j - origin_i * level2;

                    res[i, j] = nums[origin_i, origin_j];
                }
            }
            return res;
        }

        #endregion

        #region T572 问一棵树是否是另一棵树的子树

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s == null || t == null) return false;

            //递归查询t是在s左子树还是右子树
            if (true == IsSameTrees(s, t))
                return true;
            return IsSubtree(s.left, t) | IsSubtree(s.right, t);
        }

        private bool IsSameTrees(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s == null || t == null) return false;

            if (s.val != t.val) return false;
            return IsSameTrees(s.left, t.left) && IsSameTrees(s.right, t.right);
        }

        #endregion

        #region T575 分糖果

        public int DistributeCandies(int[] candies)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach(int c in candies)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            if (dict.Count >= candies.Length / 2)
            {
                return candies.Length / 2;
            }
            return dict.Count;
        }

        #endregion

        #region T581 最短无序连续子数组

        public int FindUnsortedSubarray(int[] nums)
        {
            int startIndex = -1;
            int stopIndex = - 2;

            int max = nums[0];
            int min = nums[nums.Length - 1];

            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                min = Math.Min(min, nums[nums.Length - 1 - i]);

                if (nums[i] < max) stopIndex = i;
                if (nums[nums.Length - 1 - i] > min) startIndex = nums.Length - 1 - i;
            }
            return stopIndex - startIndex + 1;
        }

        #endregion

        #region T558 四叉树交集

        public QuadTreeNode Intersect(QuadTreeNode quadTree1, QuadTreeNode quadTree2)
        {
            if (quadTree1.isLeaf == true && quadTree2.isLeaf == true)
            {
                quadTree1.val = quadTree1.val | quadTree2.val;
                return quadTree1;
            }             
            else if (quadTree1.isLeaf == true || quadTree2.isLeaf == true)
            {
                QuadTreeNode node1 = quadTree1.isLeaf == true ? quadTree1 : quadTree2;
                QuadTreeNode node2 = node1 == quadTree1 ? quadTree2 : quadTree1;
                if (node1.val == true) return node1;
                return node2;
            }
            else
            {
                quadTree1.topLeft = Intersect(quadTree1.topLeft, quadTree2.topLeft);
                quadTree1.topRight = Intersect(quadTree1.topRight, quadTree2.topRight);
                quadTree1.bottomLeft = Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
                quadTree1.bottomRight = Intersect(quadTree1.bottomRight, quadTree2.bottomRight);
                
                //如果四个子节点都是叶子且它们的值相等，则合并四个子节点为一个节点
                if (quadTree1.topLeft.isLeaf && quadTree1.topRight.isLeaf && quadTree1.bottomLeft.isLeaf && quadTree1.bottomRight.isLeaf
                    && quadTree1.topLeft.val == quadTree1.topRight.val && quadTree1.topLeft.val == quadTree1.bottomLeft.val && quadTree1.topLeft.val == quadTree1.bottomRight.val)
                {
                    quadTree1.isLeaf = true;
                    quadTree1.val = quadTree1.topLeft.val;
                    quadTree1.topLeft = null;
                    quadTree1.topRight = null;
                    quadTree1.bottomLeft = null;
                    quadTree1.bottomRight = null;
                }

                return quadTree1;
            }
        }

        #endregion

        #region T559 N叉树的最大深度

        public int MaxDepth(NTreeNode root)
        {
            if (root == null) return 0;

            int maxSubDepth = 0;
            if (root.children != null)
            {
                foreach (var node in root.children)
                {
                    int nodeDepth = MaxDepth(node);
                    if (nodeDepth > maxSubDepth) maxSubDepth = nodeDepth;
                }
            }
            return maxSubDepth + 1;
        }

        #endregion

        #region T589 N叉树的前序遍历
        //不使用递归
        public IList<int> Preorder(NTreeNode root)
        {
            List<int> res = new List<int>();

            if (root == null) return res;
            
            Stack<NTreeNode> stk = new Stack<NTreeNode>();
            stk.Push(root);
            while (stk.Count > 0)
            {
                NTreeNode node = stk.Pop();
                res.Add(node.val);
                if (node.children != null)
                {
                    for (int i = node.children.Count - 1; i >= 0; i--)
                    {
                        stk.Push(node.children[i]);
                    }
                }
            }
            return res;
        }

        #endregion

        #region T590 N叉树的后序遍历

        public IList<int> Postorder(NTreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;

            Stack<NTreeNode> stk = new Stack<NTreeNode>();
            stk.Push(root);
            while (stk.Count > 0)
            {
                NTreeNode node = stk.Pop();
                res.Add(node.val);
                if (node.children != null)
                {
                    for (int i = 0; i < node.children.Count; i++)
                    {
                        stk.Push(node.children[i]);
                    }
                }
            }
            res.Reverse();
            return res;
        }

        #endregion

        #region T594 最长和谐子序列

        public int FindLHS(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int n in nums)
            {
                if (dict.ContainsKey(n))
                    dict[n]++;
                else
                    dict.Add(n, 1);
            }
            int[] keys = dict.Keys.ToArray();
            Array.Sort(keys);
            int maxHarmony = 0;
            for (int i = 0; i < keys.Length - 1; i++)
            {
                if (Math.Abs(keys[i] - keys[i+1]) == 1)
                {
                    int harmony = dict[keys[i]] + dict[keys[i + 1]];
                    if (harmony > maxHarmony) maxHarmony = harmony;
                }
            }
            return maxHarmony;
        }

        #endregion
    }
}
