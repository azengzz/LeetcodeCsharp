﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode.Simples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples.Tests
{
    [TestClass()]
    public class T168_SomeMathProblemsTests
    {
        T168_SomeMathProblems t168 = new T168_SomeMathProblems();

        #region T168 tests ：将数字转换为EXCEL中列的表示形式（26进制）

        [TestMethod()]
        public void ConvertToTitleTest_1()
        {
            int num = 1;
            string expect = "A";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_2()
        {
            int num = 26;
            string expect = "Z";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_3()
        {
            int num = 28;
            string expect = "AB";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_4()
        {
            int num = 701;
            string expect = "ZY";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_5()
        {
            int num = 702;
            string expect = "ZZ";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_6()
        {
            int num = 703;
            string expect = "AAA";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_7()
        {
            int num = 728;
            string expect = "AAZ";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_8()
        {
            int num = 18954;
            string expect = "AAZZ";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        [TestMethod()]
        public void ConvertToTitleTest_9()
        {
            int num = 18955;
            string expect = "ABAA";
            Assert.AreEqual(expect, t168.ConvertToTitle(num));
        }

        #endregion

        #region T169 tests ： 寻找众数

        [TestMethod()]
        public void MajorityElementTest_1()
        {
            int[] nums = { 3, 2, 3 };
            int expect = 3;
            Assert.AreEqual(expect, t168.MajorityElement(nums));
        }

        [TestMethod()]
        public void MajorityElementTest_2()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
            int expect = 2;
            Assert.AreEqual(expect, t168.MajorityElement(nums));
        }

        [TestMethod()]
        public void MajorityElementTest_3()
        {
            int[] nums = { 10 };
            int expect = 10;
            Assert.AreEqual(expect, t168.MajorityElement(nums));
        }

        [TestMethod()]
        public void MajorityElementTest_4()
        {
            int[] nums = { 1, 7, 11, 7, 11, 2, 5, 6, 7, 7, 6, 6, 11, 11, 11, 11, 11, 11, 3, 4, 5, 11, 11, 11, 11, 11 };
            int expect = 11;
            Assert.AreEqual(expect, t168.MajorityElement(nums));
        }

        [TestMethod()]
        public void MajorityElementTest_5()   //数组中众数有2个时？
        {
            int[] nums = { 3, 2, 2, 3 };
            int expect = 2;
            Assert.AreEqual(expect, t168.MajorityElement(nums));
        }

        [TestMethod()]
        public void MajorityElementTest_6()    //从运行结果看，跟哪个数字出现的次数先超过n/2有关
        {
            int[] nums = { 2, 3, 3, 2 };
            int expect = 3;
            Assert.AreEqual(expect, t168.MajorityElement(nums));
        }

        [TestMethod()]
        public void MajorityElementTest_7()
        {
            int[] nums = { 6, 5, 5 };
            int expect = 5;
            Assert.AreEqual(expect, t168.MajorityElement(nums));
        }

        #endregion

        #region T171 test ：给定一个EXCEL表格中的列名称，返回其对应的列序号

        [TestMethod()]
        public void TitleToNumberTest_1()
        {
            int expect = 1;
            Assert.AreEqual(expect, t168.TitleToNumber("A"));
        }

        [TestMethod()]
        public void TitleToNumberTest_2()
        {
            int expect = 26;
            Assert.AreEqual(expect, t168.TitleToNumber("Z"));
        }

        [TestMethod()]
        public void TitleToNumberTest_3()
        {
            int expect = 52;
            Assert.AreEqual(expect, t168.TitleToNumber("AZ"));
        }

        [TestMethod()]
        public void TitleToNumberTest_4()
        {
            int expect = 702;
            Assert.AreEqual(expect, t168.TitleToNumber("ZZ"));
        }

        [TestMethod()]
        public void TitleToNumberTest_5()
        {
            int expect = 18956;
            Assert.AreEqual(expect, t168.TitleToNumber("ABAB"));
        }

        #endregion

        #region T172 计算某个正整数阶乘的结果尾部有几个0
        [TestMethod()]
        public void TrailingZeroesTest_1()
        {

            Assert.AreEqual(1, t168.TrailingZeroes(6));
        }

        [TestMethod()]
        public void TrailingZeroesTest_2()
        {
            int expect = 7;
            int result = t168.TrailingZeroes(30);
            Assert.AreEqual(expect, result);
        }

        [TestMethod()]
        public void TrailingZeroesTest_3()
        {
            int expect = 24;
            int result = t168.TrailingZeroes(100);
            Assert.AreEqual(expect, result);
        }

        [TestMethod()]
        public void TrailingZeroesTest_4()
        {
            int expect = 249;
            int result = t168.TrailingZeroes(1001);
            Assert.AreEqual(expect, result);
        }

        [TestMethod()]
        public void TrailingZeroesTest_5()
        {
            int expect = 452137076;
            int result = t168.TrailingZeroes(1808548329);
            Assert.AreEqual(expect, result);
        }

        #endregion

        #region T189 Test : 旋转数组

        [TestMethod()]
        public void RotateTest_1()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 4;
            int[] expect = { 4, 5, 6, 7, 1, 2, 3 };
            t168.Rotate(nums, k);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        [TestMethod()]
        public void RotateTest_2()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
                61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
                71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
                91, 92, 93, 94, 95, 96, 97, 98, 99, 100
            };
            int k = 42;
            int[] expect = { 59, 60,
                61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
                71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
                91, 92, 93, 94, 95, 96, 97, 98, 99, 100,
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                51, 52, 53, 54, 55, 56, 57, 58, 
            };
            t168.Rotate(nums, k);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        [TestMethod()]
        public void RotateTest_3()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 37;
            int[] expect = { 6, 7, 1, 2, 3, 4, 5 };
            t168.Rotate(nums, k);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        #endregion
    }
}