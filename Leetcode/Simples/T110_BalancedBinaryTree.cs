using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T110_BalancedBinaryTree
    {
        public T110_BalancedBinaryTree()
        {
        }

        /*
          Given a binary tree, determine if it is height-balanced.
          For this problem, a height-balanced binary tree is defined as:
          a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
         */

        public bool IsBalanced(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return true;
            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);
            if (leftHeight - rightHeight > 1 || leftHeight - rightHeight < -1)
                return false;
            return IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            return leftHeight >= rightHeight ? leftHeight + 1 : rightHeight + 1;
        }
    }
}
