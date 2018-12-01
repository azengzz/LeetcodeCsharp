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
    public class T349_MathProblemsTests
    {
        T349_MathProblems t349 = new T349_MathProblems();

        #region T349 tests : 求两个数组的交集

        [TestMethod()]
        public void IntersectionTest_1()
        {
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] res = t349.Intersection(nums1, nums2);
            int[] expect = { 2 };
            Assert.IsTrue(CompareHelper.CompareArrays(res, expect));
        }

        [TestMethod()]
        public void IntersectionTest_2()
        {
            int[] nums1 = { 4, 9, 5 };
            int[] nums2 = { 9, 4, 9, 8, 4 };
            int[] res = t349.Intersection(nums1, nums2);
            int[] expect = { 9, 4 };
            Assert.IsTrue(CompareHelper.CompareArrays(res, expect));
        }

        [TestMethod()]
        public void IntersectionTest_3()
        {
            int[] nums1 = { };
            int[] nums2 = { 9, 4, 9, 8, 4 };
            int[] res = t349.Intersection(nums1, nums2);
            int[] expect = { };
            Assert.IsTrue(CompareHelper.CompareArrays(res, expect));
        }

        #endregion

        #region T350 tests : 求两个数组的交集

        [TestMethod()]
        public void Intersect_IITest_1()
        {
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] res = t349.Intersect_II(nums1, nums2);
            int[] expect = { 2, 2 };
            Assert.IsTrue(CompareHelper.CompareArrays(res, expect));
        }

        [TestMethod()]
        public void Intersect_IITest_2()
        {
            int[] nums1 = { 4, 9, 5 };
            int[] nums2 = { 9, 4, 9, 8, 4 };
            int[] res = t349.Intersect_II(nums1, nums2);
            int[] expect = { 9, 4 };
            Assert.IsTrue(CompareHelper.CompareArrays(res, expect));
        }

        [TestMethod()]
        public void Intersect_IITest_3()
        {
            int[] nums1 = { };
            int[] nums2 = { 9, 4, 9, 8, 4 };
            int[] res = t349.Intersect_II(nums1, nums2);
            int[] expect = { };
            Assert.IsTrue(CompareHelper.CompareArrays(res, expect));
        }


        #endregion

        #region T367 tests : 问一个正整数是否是完全平方数

        [TestMethod()]
        public void IsPerfectSquareTest_1()
        {
            Assert.IsTrue(true == t349.IsPerfectSquare(25));
        }

        [TestMethod()]
        public void IsPerfectSquareTest_2()
        {
            Assert.IsTrue(false == t349.IsPerfectSquare(26));
        }

        [TestMethod()]
        public void IsPerfectSquareTest_3()
        {
            Assert.IsTrue(false == t349.IsPerfectSquare(int.MaxValue));
        }

        [TestMethod()]
        public void IsPerfectSquareTest_4()
        {
            Assert.IsTrue(true == t349.IsPerfectSquare(4));
        }

        [TestMethod()]
        public void IsPerfectSquareTest_5()
        {
            Assert.IsTrue(true == t349.IsPerfectSquare(1));
        }

        [TestMethod()]
        public void IsPerfectSquareTest_6()
        {
            Assert.IsTrue(false == t349.IsPerfectSquare(2));
        }

        #endregion

        #region T371 tests : 两整数相加，不适用+号和-号

        [TestMethod()]
        public void GetSumTest_1()
        {
            Assert.IsTrue(6 == t349.GetSum(3, 3));
        }

        [TestMethod()]
        public void GetSumTest_2()
        {
            Assert.IsTrue(300 == t349.GetSum(100, 200));
        }

        [TestMethod()]
        public void GetSumTest_3()
        {
            Assert.IsTrue(1 == t349.GetSum(-1, 2));
        }

        #endregion

        #region T374 tests : 猜数字大小

        [TestMethod()]
        public void guessNumberTest_1()
        {
            Assert.IsTrue(6 == t349.guessNumber(10));
        }

        [TestMethod()]
        public void guessNumberTest_2()
        {
            Assert.IsTrue(6 == t349.guessNumber(6));
        }

        #endregion
    }
}