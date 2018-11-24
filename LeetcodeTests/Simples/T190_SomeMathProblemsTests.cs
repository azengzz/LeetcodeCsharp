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
    public class T190_SomeMathProblemsTests
    {
        T190_SomeMathProblems t190 = new T190_SomeMathProblems();

        #region T190 tests : 颠倒二进制位

        [TestMethod()]
        public void reverseBitsTest_1()
        {
            uint origin = 11;
            uint expect = 3489660928;
            uint result = t190.reverseBits(origin);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void reverseBitsTest_2()
        {
            uint origin = 43261596;
            uint expect = 964176192;
            uint result = t190.reverseBits(origin);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void reverseBitsTest_3()
        {
            uint origin = 1;
            uint expect = 2147483648;
            uint result = t190.reverseBits(origin);
            Assert.IsTrue(expect == result);
        }

        #endregion

        #region T191 tests : 位1的个数

        [TestMethod()]
        public void HammingWeightTest_1()
        {
            uint input = 11;
            int expect = 3;
            Assert.IsTrue(expect == t190.HammingWeight(input));
        }

        [TestMethod()]
        public void HammingWeightTest_2()
        {
            uint input = 128;
            int expect = 1;
            Assert.IsTrue(expect == t190.HammingWeight(input));
        }

        #endregion

        #region T196 tests : House Robber

        [TestMethod()]
        public void RobTest_1()
        {
            int[] nums = { 2, 1, 1, 2 };
            Assert.IsTrue(4 == t190.Rob(nums));
        }

        [TestMethod()]
        public void RobTest_2()
        {
            int[] nums = { 2, 7, 9, 3, 1 };
            Assert.IsTrue(12 == t190.Rob(nums));
        }

        #endregion

        #region tests : T202 Is Happy Number

        [TestMethod()]
        public void IsHappyTest_1()
        {
            Assert.IsTrue(true == t190.IsHappy(19));
        }

        [TestMethod()]
        public void IsHappyTest_2()
        {
            Assert.IsTrue(false == t190.IsHappy(20));
        }

        [TestMethod()]
        public void IsHappyTest_3()
        {
            Assert.IsTrue(true == t190.IsHappy(1111112));
        }

        #endregion

        #region T203 tests : 移除链表元素

        [TestMethod()]
        public void RemoveElementsTest_1()
        {
            int[] nodes = { 1, 2, 6, 3, 4, 5, 6 };
            ListNode lst = ListNodeHelper.CreateLinkedListByArray(nodes);
            ListNode result = t190.RemoveElements(lst, 3);
            int[] resultArr = ListNodeHelper.GetElementsFromLinkedList(result);
            int[] expect = { 1, 2, 6, 4, 5, 6 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, resultArr));
        }

        [TestMethod()]
        public void RemoveElementsTest_2()
        {
            int[] nodes = { 1, 2, 6, 3, 4, 5, 6 };
            ListNode lst = ListNodeHelper.CreateLinkedListByArray(nodes);
            ListNode result = t190.RemoveElements(lst, 6);
            int[] resultArr = ListNodeHelper.GetElementsFromLinkedList(result);
            int[] expect = { 1, 2, 3, 4, 5 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, resultArr));
        }

        [TestMethod()]
        public void RemoveElementsTest_3()
        {
            int[] nodes = { 1, 2, 6, 3, 4, 5, 6 };
            ListNode lst = ListNodeHelper.CreateLinkedListByArray(nodes);
            ListNode result = t190.RemoveElements(lst, 8);
            int[] resultArr = ListNodeHelper.GetElementsFromLinkedList(result);
            int[] expect = { 1, 2, 6, 3, 4, 5, 6 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, resultArr));
        }

        [TestMethod()]
        public void RemoveElementsTest_4()
        {
            int[] nodes = { 1, 2, 6, 3, 4, 5, 6 };
            ListNode lst = ListNodeHelper.CreateLinkedListByArray(nodes);
            ListNode result = t190.RemoveElements(lst, 1);
            int[] resultArr = ListNodeHelper.GetElementsFromLinkedList(result);
            int[] expect = { 2, 6, 3, 4, 5, 6 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, resultArr));
        }

        [TestMethod()]
        public void RemoveElementsTest_5()
        {
            int[] nodes = { 6, 6, 6, 6, 6, 6 };
            ListNode lst = ListNodeHelper.CreateLinkedListByArray(nodes);
            ListNode result = t190.RemoveElements(lst, 6);
            Assert.IsTrue(result == null);
        }

        [TestMethod()]
        public void RemoveElementsTest_6()
        {
            int[] nodes = { 1, 2, 2, 1 };
            ListNode lst = ListNodeHelper.CreateLinkedListByArray(nodes);
            ListNode result = t190.RemoveElements(lst, 2);
            int[] resultArr = ListNodeHelper.GetElementsFromLinkedList(result);
            int[] expect = { 1, 1 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, resultArr));
        }

        #endregion

        #region T204 tests :  计数质数
        [TestMethod()]
        public void CountPrimesTest_1()
        {
            Assert.IsTrue(2 == t190.CountPrimes(5));
        }

        [TestMethod()]
        public void CountPrimesTest_2()
        {
            Assert.IsTrue(4 == t190.CountPrimes(10));
        }

        [TestMethod()]
        public void CountPrimesTest_3()
        {
            Assert.IsTrue(35 == t190.CountPrimes(150));
        }

        #endregion

        #region T205 tests : 同构字符串

        [TestMethod()]
        public void IsIsomorphicTest_1()
        {
            Assert.IsTrue(true == t190.IsIsomorphic("egg", "add"));
        }

        [TestMethod()]
        public void IsIsomorphicTest_2()
        {
            Assert.IsTrue(false == t190.IsIsomorphic("foo", "bar"));
        }

        [TestMethod()]
        public void IsIsomorphicTest_3()
        {
            Assert.IsTrue(false == t190.IsIsomorphic("bar", "foo"));
        }

        [TestMethod()]
        public void IsIsomorphicTest_4()
        {
            Assert.IsTrue(true == t190.IsIsomorphic("paper", "title"));
        }

        [TestMethod()]
        public void IsIsomorphicTest_5()
        {
            Assert.IsTrue(true == t190.IsIsomorphic("", ""));
        }

        #endregion
    }
}