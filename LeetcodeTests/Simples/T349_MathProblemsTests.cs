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

        #region T383 tests : 赎金信

        [TestMethod()]
        public void CanConstructTest_1()
        {
            Assert.IsTrue(true == t349.CanConstruct("hello", "helloworld"));
        }

        [TestMethod()]
        public void CanConstructTest_2()
        {
            Assert.IsTrue(false == t349.CanConstruct("a", "b"));
        }

        [TestMethod()]
        public void CanConstructTest_3()
        {
            Assert.IsTrue(false == t349.CanConstruct("aa", "ab"));
        }

        [TestMethod()]
        public void CanConstructTest_4()
        {
            Assert.IsTrue(true == t349.CanConstruct("aa", "aab"));
        }

        #endregion

        #region T387 tests : 求字符串中第一个唯一字符的下标

        [TestMethod()]
        public void FirstUniqCharTest_1()
        {
            Assert.IsTrue(0 == t349.FirstUniqChar("leetcode"));
        }

        [TestMethod()]
        public void FirstUniqCharTest_2()
        {
            Assert.IsTrue(2 == t349.FirstUniqChar("loveleetcode"));
        }

        [TestMethod()]
        public void FirstUniqCharTest_3()
        {
            Assert.IsTrue(-1 == t349.FirstUniqChar("leetcodeleetcode"));
        }


        #endregion

        #region T389 tests : 找两个字符中不同的那个字符

        [TestMethod()]
        public void FindTheDifferenceTest_1()
        {
            Assert.IsTrue('e' == t349.FindTheDifference("abcd", "caebd"));
        }

        [TestMethod()]
        public void FindTheDifferenceTest_2()
        {
            Assert.IsTrue('A' == t349.FindTheDifference("", "A"));
        }

        #endregion

        #region T400 tesst : 求第N个数字

        [TestMethod()]
        public void FindNthDigitTest_1()
        {
            Assert.IsTrue(8 == t349.FindNthDigit(187));
        }

        [TestMethod()]
        public void FindNthDigitTest_2()
        {
            Assert.IsTrue(9 == t349.FindNthDigit(2882));
        }

        [TestMethod()]
        public void FindNthDigitTest_3()
        {
            Assert.IsTrue(4 == t349.FindNthDigit(114514));
        }

        [TestMethod()]
        public void findnthdigittest_4()
        {
            Assert.IsTrue(2 == t349.FindNthDigit(int.MaxValue - 1));
        }

        #endregion

        #region T401 tests : 二进制手表

        [TestMethod()]
        public void CreateNOnesTest_1()
        {
            Assert.IsTrue(null != t349.CreateNOnes(4, 1));
        }

        [TestMethod()]
        public void CreateNOnesTest_2()
        {
            Assert.IsTrue(null != t349.CreateNOnes(4, 2));
        }

        [TestMethod()]
        public void CreateNOnesTest_3()
        {
            Assert.IsTrue(null != t349.CreateNOnes(4, 3));
        }

        [TestMethod()]
        public void ReadBinaryWatchTest_1()
        {
            Assert.IsTrue(null != t349.ReadBinaryWatch(8));
        }

        [TestMethod()]
        public void ReadBinaryWatchTest_2()
        {
            Assert.IsTrue(null != t349.ReadBinaryWatch(7));
        }

        [TestMethod()]
        public void ReadBinaryWatchTest_3()
        {
            Assert.IsTrue(null != t349.ReadBinaryWatch(1));
        }

        [TestMethod()]
        public void ReadBinaryWatchTest_4()
        {
            Assert.IsTrue(null != t349.ReadBinaryWatch(0));
        }

        #endregion
    }
}