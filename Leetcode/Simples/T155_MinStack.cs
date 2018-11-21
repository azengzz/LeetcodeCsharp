using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    //T155 实现一个栈的最小功能集

    public class T155_MinStack
    {
        private List<int> stk = null;

        public T155_MinStack()
        {
            stk = new List<int>();
        }

        public void Push(int x)
        {
            stk.Add(x);
        }

        public void Pop()
        {
            stk.RemoveAt(stk.Count - 1);
        }

        public int Top()
        {
            return stk[stk.Count - 1];
        }

        public int GetMin()
        {
            return stk.Min();
        }
    }
}
