using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T108_BinarySearchTree
    {
        public T108_BinarySearchTree()
        {
        }

        /*
         Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
         For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of
         the two subtrees of every node never differ by more than 1.

            Example:
            Given the sorted array: [-10,-3,0,5,9],
            One possible answer is: [0,-3,9,-10,null,5]
         */

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null) return null;
            return CreateTree(nums, 0, nums.Length - 1);
        }

        private TreeNode CreateTree(int[] nums, int start, int end)
        {
            if (start == end)
            {
                return new TreeNode(nums[start]);
            }
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(nums[mid]);

            node.left = CreateTree(nums, start, mid - 1);
            node.right = CreateTree(nums, mid + 1, end);

            return node;
        }
    }
}
