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
    public class T88_MergeSortedArraysTests
    {
        T88_MergeSortedArrays t88 = new T88_MergeSortedArrays();

        [TestMethod()]
        public void MergeTest_1()
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 4, 5, 6 };
            t88.Merge(nums1, 3, nums2, 3);
            int[] expected = { 1, 2, 3, 4, 5, 6 };
            Assert.IsTrue(CompareHelper.CompareArrays(nums1, expected));
        }

        [TestMethod()]
        public void MergeTest_2()
        {
            int[] nums1 = { 4, 5, 6, 0, 0, 0 };
            int[] nums2 = { 1, 2, 3 };
            t88.Merge(nums1, 3, nums2, 3);
            int[] expected = { 1, 2, 3, 4, 5, 6 };
            Assert.IsTrue(CompareHelper.CompareArrays(nums1, expected));
        }

        [TestMethod()]
        public void MergeTest_3()
        {
            int[] nums1 = { 1, 3, 5, 0, 0, 0 };
            int[] nums2 = { 2, 4, 6 };
            t88.Merge(nums1, 3, nums2, 3);
            int[] expected = { 1, 2, 3, 4, 5, 6 };
            Assert.IsTrue(CompareHelper.CompareArrays(nums1, expected));
        }

        [TestMethod()]
        public void MergeTest_4()
        {
            int[] nums1 = { 0, 0, 0 };
            int[] nums2 = { 2, 4, 6 };
            t88.Merge(nums1, 0, nums2, 3);
            int[] expected = { 2, 4, 6 };
            Assert.IsTrue(CompareHelper.CompareArrays(nums1, expected));
        }

        [TestMethod()]
        public void MergeTest_5()
        {
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = {  };
            t88.Merge(nums1, 3, nums2, 0);
            int[] expected = { 1, 2, 3 };
            Assert.IsTrue(CompareHelper.CompareArrays(nums1, expected));
        }
    }
}