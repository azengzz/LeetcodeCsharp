﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    #region 链表
    //链表节点数据结构
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class ListNodeHelper
    {
        /*
         * 根据数组生成链表
         */
        public static ListNode CreateLinkedListByArray(int[] elements)
        {
            if (elements == null) return null;

            ListNode node0 = new ListNode(elements[0]) { next = null };
            ListNode head = node0;
            ListNode walk = head;
            for (int i = 1; i < elements.Length; i++)
            {
                ListNode node = new ListNode(elements[i]) { next = null };
                walk.next = node;
                walk = walk.next;
            }
            return head;
        }

        /*
         * 从链表中取出数字组成数组
         */
        public static int[] GetElementsFromLinkedList(ListNode head)
        {
            List<int> elements = new List<int>();
            while (head != null)
            {
                elements.Add(head.val);
                head = head.next;
            }
            return elements.ToArray();
        }     
    }

    #endregion

    #region 用于比较
    public class CompareHelper
    {
        /*
         * 逐个元素比较两个int型数组是否完全相同
         */
        public static bool CompareArrays(int[] arr1, int[] arr2)
        {
            if (arr1 == null && arr2 == null) return true;
            if (arr1.Length != arr2.Length) return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }

        public static bool CompareArrays<T>(T[] arr1, T[] arr2)
        {
            if (arr1 == null && arr2 == null) return true;
            if (arr1.Length != arr2.Length) return false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == null && arr2[i] == null) continue;
                if ((arr1[i] == null && arr2[i] != null) || (arr1[i] != null && arr2[i] == null)) return false;
                if (!arr1[i].Equals(arr2[i])) return false;                 
            }
            return true;
        }

        public static bool CompareList<T>(IList<T> list1, IList<T> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] == null && list2[i] == null) continue;
                if (list1[i] == null || list2[i] == null) return false;
                if (!list1[i].Equals(list2[i])) return false;
            }
            return true;
        }

        public static bool CompareListList(IList<IList<int>> expect, IList<IList<int>> result)
        {
            if (expect.Count != result.Count) return false;

            for (int i = 0; i < result.Count; i++)
            {
                if (expect[i].Count != result[i].Count) return false;
                for (int j = 0; j < result[i].Count; j++)
                {
                    if (result[i][j] != expect[i][j]) return false;
                }
            }

            return true;
        }

        public static bool CompareTwoDimensionalArray<T>(T[,] arr1, T[,] arr2)
        {
            if (arr1 == null && arr2 == null) return true;            
            if (arr1.GetLength(0) != arr2.GetLength(0) || arr1.GetLength(1) != arr2.GetLength(1)) return false;

            int rows = arr1.GetLength(0);
            int cols = arr1.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr1[i,j] == null && arr2[i,j] == null) continue;
                    if (arr1[i,j] == null || arr2[i,j] == null) return false;
                    if (!arr1[i,j].Equals(arr2[i,j])) return false;
                }                
            }
            return true;
        }
    }

    #endregion

    #region 二叉树

    //二叉树节点数据结构
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class TreeHelper
    {
        /*
         * 从给定的数组创造二叉树（不一定是完全二叉树，不完全二叉树也可以创建）
         */
        public static TreeNode CreateBinaryTreeByArray(object[] arr)
        {
            if (arr == null || arr.Length == 0) return null;

            TreeNode root = new TreeNode((int)arr[0]);
            List<TreeNode> nodes = new List<TreeNode>();
            nodes.Add(root);
            int nodesPtr = 0;
            for (int arrPtr = 0; arrPtr < arr.Length; )
            {
                if (nodes[nodesPtr] == null)
                {
                    nodesPtr++;
                    nodes.Add(null);
                    continue;
                }
                if (++arrPtr < arr.Length && arr[arrPtr] != null)
                {
                    TreeNode leftNode = new TreeNode((int)arr[arrPtr]);
                    nodes[nodesPtr].left = leftNode;
                    nodes.Add(leftNode); 
                }
                if (++arrPtr < arr.Length && arr[arrPtr] != null)
                {
                    TreeNode rightNode = new TreeNode((int)arr[arrPtr]);
                    nodes[nodesPtr].right = rightNode;
                    nodes.Add(rightNode);
                }
                nodesPtr++;
            }
            return root;
        }

        /*
         * 先序遍历得到树的各值，存入线性表中
         */
        public static void PreOrderGetElements(TreeNode tree, List<object> list)
        {
            if (tree == null)
            {
                list.Add(null);
                return;
            }

            list.Add(tree.val);
            PreOrderGetElements(tree.left, list);
            PreOrderGetElements(tree.right, list);
        }

        /*
         * 层序遍历（广度优先遍历）
         */
         public static object[] BreadthFirstTraverse(TreeNode tree)
        {
            List<object> res = new List<object>();

            if (tree == null) return res.ToArray();
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(tree);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                    res.Add(null);
                else
                    res.Add(node.val);
                if (node != null && (node.left != null || node.right != null))
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            return res.ToArray();
        }
    }

    #endregion

    #region 单向链表

    // 单向链表节点定义
    public class SingleListNode
    {
        public int val;
        public SingleListNode next;
        public SingleListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class LinkedListHelper
    {
        public static SingleListNode CreateSingleListedListByArray(int[] elements)
        {
            if (elements == null) return null;

            SingleListNode ptr = new SingleListNode(elements[0]);
            SingleListNode head = ptr;
            for (int i = 1; i < elements.Length; i++)
            {
                ptr.next = new SingleListNode(elements[i]);
                ptr = ptr.next;
            }
            return head;
        }
    }

    #endregion

    #region 四叉树

    public class QuadTreeNode
    {
        public bool val;
        public bool isLeaf;
        public QuadTreeNode topLeft;
        public QuadTreeNode topRight;
        public QuadTreeNode bottomLeft;
        public QuadTreeNode bottomRight;

        public QuadTreeNode() { }
        public QuadTreeNode(bool _val, bool _isLeaf, QuadTreeNode _topLeft, QuadTreeNode _topRight, QuadTreeNode _bottomLeft,
                            QuadTreeNode _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    #endregion

    #region N叉树

    public class NTreeNode
    {
        public int val;
        public IList<NTreeNode> children;

        public NTreeNode() { }
        public NTreeNode(int _val, IList<NTreeNode> _children)
        {
            val = _val;
            children = _children;
        }
    }

    #endregion
}
