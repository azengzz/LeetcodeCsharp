using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    #region T225 用队列实现栈

    public class T225_MyStackUsingQueue
    {
        private Queue<int> stk = null;

        public T225_MyStackUsingQueue()
        {
            stk = new Queue<int>();
        }

        public void Push(int x)
        {
            stk.Enqueue(x);
        }

        public int Pop()
        {
            if (stk.Count == 0)
            {
                throw new Exception("pop from empty list");
            }
            //把队列头节点拿出来，再添加回队尾
            for (int i = 0; i < stk.Count - 1; i++)
            {
                int first = stk.Dequeue();
                stk.Enqueue(first);
            }
            return stk.Dequeue();
        }

        public int Top()
        {
            return stk.Last<int>();
        }

        public bool Empty()
        {
            return stk.Count == 0;
        }       
    }

    #endregion

    #region T226 翻转二叉树

    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            //用队列实现广度优先算法，并将出队的节点的左右指针互换
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                TreeNode head = queue.Dequeue();
                TreeNode left = head.left, right = head.right;
                if (head.left != null)
                {
                    queue.Enqueue(head.left);
                }
                if (head.right != null)
                {
                    queue.Enqueue(head.right);
                }
                head.left = right;
                head.right = left;
            }
            return root;
        }
    }

    #endregion

    #region T232 用栈实现队列

    //思路是：一个栈A用于进队列，另一个栈B用于出队列。当要求出队列，而B栈为空的时候，就把A栈全部出栈放到B栈，然后从B栈出栈一个节点
    public class MyQueue
    {
        private Stack<int> enqueue;
        private Stack<int> dequeue;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            enqueue = new Stack<int>();
            dequeue = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            enqueue.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if (dequeue.Count == 0)
            {
                while (enqueue.Count > 0)    //将enqueue中的所有节点放到dequeue中
                {
                    dequeue.Push(enqueue.Pop());
                }
            }           
            return dequeue.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            if (dequeue.Count == 0)
            {
                while (enqueue.Count > 0)    //将enqueue中的所有节点放到dequeue中
                {
                    dequeue.Push(enqueue.Pop());
                }
            }
            return dequeue.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return (enqueue.Count + dequeue.Count) == 0;
        }
    }

    #endregion

    
}
