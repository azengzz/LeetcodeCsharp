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
    public class T121_StockBuySellTests
    {
        T121_StockBuySell t121 = new T121_StockBuySell();

        [TestMethod()]
        public void MaxProfitTest_1()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Assert.IsTrue(5 ==  t121.MaxProfit(prices));
        }

        [TestMethod()]
        public void MaxProfitTest_2()
        {
            int[] prices = { 7 };
            Assert.IsTrue(0 == t121.MaxProfit(prices));
        }

        [TestMethod()]
        public void MaxProfitTest_3()
        {
            int[] prices = null;
            Assert.IsTrue(0 == t121.MaxProfit(prices));
        }

        [TestMethod()]
        public void MaxProfitTest_4_allTheSame()
        {
            int[] prices = { 2, 2, 2, 2, 2, 2, 2, 2, 2, };
            Assert.IsTrue(0 == t121.MaxProfit(prices));
        }

        [TestMethod()]
        public void MaxProfitTest_5()    //倒序的数字
        {
            int[] prices = { 7, 6, 5, 4, 3, 2, 1 };
            Assert.IsTrue(0 == t121.MaxProfit(prices));
        }

        [TestMethod()]
        public void MaxProfitTest_6()
        {
            int[] prices = { 2, 4, 1 };
            Assert.IsTrue(2 == t121.MaxProfit(prices));
        }

        [TestMethod()]
        public void MaxProfitTest_7()
        {
            int[] prices = { 1, 2, 4 };
            Assert.IsTrue(3 == t121.MaxProfit(prices));
        }
    }
}