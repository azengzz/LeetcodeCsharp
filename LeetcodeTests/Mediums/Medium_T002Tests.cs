using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode.Mediums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Mediums.Tests
{
    [TestClass()]
    public class Medium_T002Tests
    {
        public Medium_T002 m02 = new Medium_T002();

        #region T02 tests : 两数相加

        [TestMethod()]
        public void AddTwoNumbersTest_1()
        {
            int[] nums1 = { 2, 4, 3 };
            int[] nums2 = { 5, 6, 4 };
            ListNode lst1 = ListNodeHelper.CreateLinkedListByArray(nums1);
            ListNode lst2 = ListNodeHelper.CreateLinkedListByArray(nums2);

            int[] expect = { 7, 0, 8 };
            int[] res = ListNodeHelper.GetElementsFromLinkedList(m02.AddTwoNumbers(lst1, lst2));

            Assert.IsTrue(CompareHelper.CompareArrays(expect, res));
        }

        [TestMethod()]
        public void AddTwoNumbersTest_2()
        {
            int[] nums1 = { 6, 7, 8, 9, 9 };
            int[] nums2 = { 1, 2, 3 };
            ListNode lst1 = ListNodeHelper.CreateLinkedListByArray(nums1);
            ListNode lst2 = ListNodeHelper.CreateLinkedListByArray(nums2);

            int[] expect = { 7, 9, 1, 0, 0, 1 };
            int[] res = ListNodeHelper.GetElementsFromLinkedList(m02.AddTwoNumbers(lst1, lst2));

            Assert.IsTrue(CompareHelper.CompareArrays(expect, res));
        }


        #endregion

        #region T03 tests : 无重复字符从最长子串长度

        [TestMethod()]
        public void LengthOfLongestSubstringTest_1()
        {
            string s = "abcabcbbefg";
            Assert.IsTrue(4 == m02.LengthOfLongestSubstring(s));
        }

        [TestMethod()]
        public void LengthOfLongestSubstringTest_2()
        {
            string s = "bbbbbb";
            Assert.IsTrue(1 == m02.LengthOfLongestSubstring(s));
        }

        [TestMethod()]
        public void LengthOfLongestSubstringTest_3()
        {
            string s = "pwwkew";
            Assert.IsTrue(3 == m02.LengthOfLongestSubstring(s));
        }

        [TestMethod()]
        public void LengthOfLongestSubstringTest_4()
        {
            string s = "abba";
            Assert.IsTrue(2 == m02.LengthOfLongestSubstring(s));
        }

        [TestMethod()]
        public void LengthOfLongestSubstringTest_5()
        {
            string s = "dvdf";
            Assert.IsTrue(3 == m02.LengthOfLongestSubstring(s));
        }

        #endregion

        #region T06 tests : Z字形变换

        [TestMethod()]
        public void ConvertTest_01()
        {
            Assert.IsTrue("LDREOEIIECIHNTSG" == m02.Convert("LEETCODEISHIRING", 4));
        }

        [TestMethod()]
        public void ConvertTest_02()
        {
            Assert.IsTrue("LEETCODEISHIRING" == m02.Convert("LEETCODEISHIRING", 100));
        }

        #endregion

        #region T08 tests : 字符串转换整数

        [TestMethod()]
        public void MyAtoiTest_1()
        {
            Assert.IsTrue(42 == m02.MyAtoi("42"));
        }

        [TestMethod()]
        public void MyAtoiTest_2()
        {
            Assert.IsTrue(-42 == m02.MyAtoi("     -42"));
        }

        [TestMethod()]
        public void MyAtoiTest_3()
        {
            Assert.IsTrue(4193 == m02.MyAtoi("4193 with words"));
        }

        [TestMethod()]
        public void MyAtoiTest_4()
        {
            Assert.IsTrue(0 == m02.MyAtoi("words and 987"));
        }

        [TestMethod()]
        public void MyAtoiTest_5()
        {
            Assert.IsTrue(-2147483648 == m02.MyAtoi("-91283472332"));
        }

        [TestMethod()]
        public void MyAtoiTest_6()
        {
            Assert.IsTrue(2147483647 == m02.MyAtoi("91283472332"));
        }

        [TestMethod()]
        public void MyAtoiTest_7()
        {
            Assert.IsTrue(4 == m02.MyAtoi("+4 2"));
        }

        [TestMethod()]
        public void MyAtoiTest_8()
        {
            Assert.IsTrue(0 == m02.MyAtoi(" "));
        }

        #endregion

        #region T11 tests : 盛水最多的容器

        [TestMethod()]
        public void MaxAreaTest_1()
        {
            int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Assert.IsTrue(49 == m02.MaxArea(height));
        }

        [TestMethod()]
        public void MaxAreaTest_2()
        {
            int[] height = { 1, 1 };
            Assert.IsTrue(1 == m02.MaxArea(height));
        }

        [TestMethod()]
        public void MaxAreaTest_3()
        {
            int[] height = { 10, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7 };
            Assert.IsTrue(161 == m02.MaxArea(height));
        }

        #endregion

        #region T12 tests : 整数转换罗马数字

        [TestMethod()]
        public void IntToRomanTest_1()
        {
            Assert.IsTrue("III" == m02.IntToRoman(3));
        }

        [TestMethod()]
        public void IntToRomanTest_2()
        {
            Assert.IsTrue("IV" == m02.IntToRoman(4));
        }

        [TestMethod()]
        public void IntToRomanTest_3()
        {
            Assert.IsTrue("IX" == m02.IntToRoman(9));
        }

        [TestMethod()]
        public void IntToRomanTest_4()
        {
            Assert.IsTrue("LVIII" == m02.IntToRoman(58));
        }

        [TestMethod()]
        public void IntToRomanTest_5()
        {
            Assert.IsTrue("MCMXCIV" == m02.IntToRoman(1994));
        }

        #endregion
    }
}