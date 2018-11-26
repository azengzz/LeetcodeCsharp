using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T235_DataStructures
    {
        #region T235 二叉搜索树的最近公共祖先

        //使用二叉搜索树的特征进行查找。如果要找的2个值都比根节点小，就在左子树找；
        //如果要找的2个节点都比根节点大，则在右子树找；
        //如果2个值在根节点两侧，或者有一个值等于根节点，则最近公共节点就是此根节点
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode bigNode = p.val > q.val ? p : q;
            TreeNode smallNode = bigNode == p ? q : p;

            if (root.val > bigNode.val)
                return LowestCommonAncestor(root.left, p, q);
            else if (root.val < smallNode.val)
                return LowestCommonAncestor(root.right, p, q);
            else
                return root;

        }

        #endregion
    }
}
