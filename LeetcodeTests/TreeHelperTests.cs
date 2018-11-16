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
    public class TreeHelperTests
    {
        [TestMethod()]
        public void CreateBinaryTreeByArrayTest_1()
        {
            object[] nodes = { 5, 4, 7, 3, null, 2, null, -1, null, 9 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            List<object> list = new List<object>();
            TreeHelper.PreOrderGetElements(tree, list);
            object[] result = list.ToArray<object>();
            object[] expected = { 5, 4, 3, -1, null, null, null, null, 7, 2, 9, null, null, null, null };    //先序遍历的期望结果
            Assert.IsTrue(CompareHelper.CompareArrays<object>(expected, result));
        }

        [TestMethod()]
        public void CreateBinaryTreeByArrayTest_2()
        {
            object[] nodes = { 1, null, 2, 3 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            List<object> list = new List<object>();
            TreeHelper.PreOrderGetElements(tree, list);
            object[] result = list.ToArray<object>();
            object[] expected = { 1, null, 2, 3, null, null, null };
            Assert.IsTrue(CompareHelper.CompareArrays<object>(expected, result));
        }
    }
}