﻿using System;
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
    }
}
