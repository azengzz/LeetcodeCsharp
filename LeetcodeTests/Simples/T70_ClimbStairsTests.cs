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
    public class T70_ClimbStairsTests
    {
        T70_ClimbStairs t70 = new T70_ClimbStairs();

        [TestMethod()]
        public void ClimbStairsTest_num0()
        {
            int stairsNum = 0;
            int expected = 1;
            int result = t70.ClimbStairs(stairsNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ClimbStairsTest_num1()
        {
            int stairsNum = 1;
            int expected = 1;
            int result = t70.ClimbStairs(stairsNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ClimbStairsTest_num2()
        {
            int stairsNum = 2;
            int expected = 2;
            int result = t70.ClimbStairs(stairsNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ClimbStairsTest_num5()
        {
            int stairsNum = 5;
            int expected = 8;
            int result = t70.ClimbStairs(stairsNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ClimbStairsTest_num6()
        {
            int stairsNum = 6;
            int expected = 13;
            int result = t70.ClimbStairs(stairsNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ClimbStairsTest_num7()
        {
            int stairsNum = 7;
            int expected = 21;
            int result = t70.ClimbStairs(stairsNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ClimbStairsTest_num40()
        {
            int stairsNum = 40;
            int expected = 165580141;
            int result = t70.ClimbStairs(stairsNum);
            Assert.AreEqual(expected, result);
        }
    }
}