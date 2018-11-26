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
    public class T225_MyStackUsingQueueTests
    {
        [TestMethod()]
        public void MyStackUsingQueueTest_1()
        {
            T225_MyStackUsingQueue mystk = new T225_MyStackUsingQueue();
            mystk.Push(1);
            mystk.Push(2);
            int param_2 = mystk.Pop();
            int param_3 = mystk.Top();
            bool param_4 = mystk.Empty();
            Assert.IsTrue(param_2 == 2 && param_3 == 1 && param_4 == false);
        }
    }
}