using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T104_BinaryTreeDepth
    {
        public T104_BinaryTreeDepth()
        {
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int left_max = MaxDepth(root.left);
            int right_max = MaxDepth(root.right);

            return left_max > right_max ? left_max + 1 : right_max + 1;


            /*
             // 官方迭代解法：利用深度优先算法(DFT)
            Stack<KeyValuePair<TreeNode, int>> stk = new Stack<KeyValuePair<TreeNode, int>>();

            if (root != null)
            {
                stk.Push(new KeyValuePair<TreeNode, int>(root, 1));
            }

            int max_depth = 0;
            while (stk.Count != 0)
            {
                KeyValuePair<TreeNode, int> pair = stk.Pop();
                TreeNode node = pair.Key;
                int depth = pair.Value;
                if (node != null)
                {
                    max_depth = depth > max_depth ? depth : max_depth;
                    stk.Push(new KeyValuePair<TreeNode, int>(node.right, depth + 1));    //按深度优先算法，先添加右子树
                    stk.Push(new KeyValuePair<TreeNode, int>(node.left, depth + 1));
                }
            }

            return max_depth;
            */
        }

        /*
           T110，找出二叉树的最小深度。
           最小深度即根到离它最近的叶子的路径上的节点个数。
           Tip：如果有一边的子树为空，则只需关注另一边的子树即可
         */
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;
            if (root.left == null) return MinDepth(root.right) + 1;
            if (root.right == null) return MinDepth(root.left) + 1;

            int leftDepth = MinDepth(root.left);
            int rightDepth = MinDepth(root.right);
            return leftDepth < rightDepth ? leftDepth + 1 : rightDepth + 1;
        }

        /*
         * T112 从根节点到叶节点，能否找到一条路径使得路径上所有节点的值之和等于某个指定的数
         */
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;    //空树
            return CalculateSum(root, 0, sum, false);
        }

        private bool CalculateSum(TreeNode node, int currentSum, int sum, bool hasBrother)
        {
            if (node == null)
            {
                if (hasBrother == false) return currentSum == sum;    // 到了叶子节点
                else return false;    //这个空节点有个兄弟节点，所以它的父节点不是叶子节点，所以这条路径(从根到这个空节点)结束，没有想要的结果
            }

            currentSum += node.val;
            if (true == CalculateSum(node.left, currentSum, sum, node.right != null)) return true;
            if (true == CalculateSum(node.right, currentSum, sum, node.left != null)) return true;

            return false;
        }
    }
}

