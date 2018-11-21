using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Tests
{
    [TestClass()]
    public class LinkedListHelperTests
    {
        [TestMethod()]
        public void CreateSingleListedListByArrayTest_1()
        {
            int[] nums = { 1, 2, 3 };
            SingleListNode list = LinkedListHelper.CreateSingleListedListByArray(nums);
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CreateSingleListedListByArrayTest_2()
        {
            int[] nums = { 11 };
            SingleListNode list = LinkedListHelper.CreateSingleListedListByArray(nums);
            Assert.IsTrue(true);
        }
    }
}