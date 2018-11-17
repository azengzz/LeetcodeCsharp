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
    public class T108_BinarySearchTreeTests
    {
        T108_BinarySearchTree t108 = new T108_BinarySearchTree();

        private object[] InputArrayOutputPreOrderBST(int[] origin)
        {
            if (origin == null) return null;

            TreeNode tree = t108.SortedArrayToBST(origin);
            List<object> resultList = new List<object>();
            TreeHelper.PreOrderGetElements(tree, resultList);
            return resultList.ToArray();
        }

        [TestMethod()]
        public void SortedArrayToBSTTest_1()
        {
            int[] origin = { -10, -3, 0, 5, 9 };
            object[] result = InputArrayOutputPreOrderBST(origin);
            object[] expect = { 0, -10, null, -3, null, null, 5, null, 9, null, null };    //先序遍历的期望值
            Assert.IsTrue(CompareHelper.CompareArrays<object>(expect, result));
        }

        [TestMethod()]
        public void SortedArrayToBSTTest_2()
        {
            int[] origin = { 1, 2, 3, 4, 5, 6, 7, 8 };
            object[] result = InputArrayOutputPreOrderBST(origin);
            object[] expect = { 4,2,1,null,null,3,null,null,6,5,null,null,7,null,8,null,null };
            Assert.IsTrue(CompareHelper.CompareArrays<object>(expect, result));
        }

        [TestMethod()]
        public void SortedArrayToBSTTest_3()
        {
            int[] origin = { 1 };
            object[] result = InputArrayOutputPreOrderBST(origin);
            object[] expect = { 1, null, null };
            Assert.IsTrue(CompareHelper.CompareArrays<object>(expect, result));
        }

        [TestMethod()]
        public void SortedArrayToBSTTest_4()
        {
            int[] origin = null;
            object[] result = InputArrayOutputPreOrderBST(origin);
            object[] expect = null;
            Assert.IsTrue(CompareHelper.CompareArrays<object>(expect, result));
        }
    }
}