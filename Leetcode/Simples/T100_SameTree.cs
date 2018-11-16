using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode;

namespace Leetcode.Simples
{
    public class T100_SameTree
    {
        public T100_SameTree()
        {
        }
        //比较两棵二叉树是否相同
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if ((p != null && q == null) || (p == null && q != null) || (p.val != q.val))
                return false;

            if (!IsSameTree(p.left, q.left)) return false;
            if (!IsSameTree(p.right, q.right)) return false;

            return true;
        }
    }
}
