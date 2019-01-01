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

        #region M02 tests : 两数相加

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
    }
}