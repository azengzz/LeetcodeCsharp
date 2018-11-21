using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode.Simples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples.Tests
{
    [TestClass()]
    public class T155_MinStackTests
    {
        [TestMethod()]
        public void T155_MinStackTest()
        {
            T155_MinStack stk = new T155_MinStack();
            stk.Push(-2);
            stk.Push(0);
            stk.Push(-3);
            int min = stk.GetMin();
            stk.Pop();
            int top = stk.Top();
            int min2 = stk.GetMin();

            int[] expect = { -3, 0, -2 };
            int[] result = { min, top, min2 };

            Assert.IsTrue(CompareHelper.CompareArrays(expect, result));
        }
    }
}