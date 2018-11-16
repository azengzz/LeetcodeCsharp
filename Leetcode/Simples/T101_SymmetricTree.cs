using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T101_SymmetricTree
    {
        public T101_SymmetricTree()
        {
        }

        //判断一棵树是否是对称的
        /*
            Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
            For example, this binary tree [1,2,2,3,4,4,3] is symmetric;
            But the following [1,2,2,null,3,null,3] is not.
         */
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return true;
            }

            List<object> arr_left = new List<object>();
            List<object> arr_right = new List<object>();

            PreOrderLeftFirst(root.left, arr_left);
            PreOrderRightFirst(root.right, arr_right);

            if (arr_left.Count != arr_right.Count) return false;

            for (int i = 0; i < arr_left.Count; i++)
            {
                if (arr_left[i] == null && arr_right[i] == null) continue;
                else if (arr_left[i] == null || arr_right[i] == null) return false;
                else if (!arr_left[i].Equals(arr_right[i])) return false;
            }

            return true;
        }

        private void PreOrderLeftFirst(TreeNode tree, List<object> list)
        {
            if (tree == null)
            {
                list.Add(null);
                return;
            }
            list.Add(tree.val);
            PreOrderLeftFirst(tree.left, list);
            PreOrderLeftFirst(tree.right, list);
        }

        private void PreOrderRightFirst(TreeNode tree, List<object> list)
        {
            if (tree == null)
            {
                list.Add(null);
                return;
            }
            list.Add(tree.val);
            PreOrderRightFirst(tree.right, list);
            PreOrderRightFirst(tree.left, list);
        }
    }
}
