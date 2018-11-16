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
    public class T100_SameTreeTests
    {
        T100_SameTree t100 = new T100_SameTree();

        [TestMethod()]
        public void IsSameTreeTest_1()
        {
            object[] nodes_arr1 = { 1, 2, 3 };
            object[] nodes_arr2 = { 1, 2, 3 };
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(nodes_arr1);
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(nodes_arr2);
            Assert.IsTrue(t100.IsSameTree(tree1, tree2));
        }

        [TestMethod()]
        public void IsSameTreeTest_2()
        {
            object[] nodes_arr1 = { 1, 2 };
            object[] nodes_arr2 = { 1, null, 2 };
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(nodes_arr1);
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(nodes_arr2);
            Assert.IsFalse(t100.IsSameTree(tree1, tree2));
        }

        [TestMethod()]
        public void IsSameTreeTest_3()
        {
            object[] nodes_arr1 = { 1, 2, 1 };
            object[] nodes_arr2 = { 1, 1, 2 };
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(nodes_arr1);
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(nodes_arr2);
            Assert.IsFalse(t100.IsSameTree(tree1, tree2));
        }

        [TestMethod()]
        public void IsSameTreeTest_4()
        {
            object[] nodes_arr1 = { 5, 4, 7, 3, null, 2, null, -1, null, 9 };
            object[] nodes_arr2 = { 5, 4, 7, 3, null, 2, null, -1, null, 9, null };
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(nodes_arr1);
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(nodes_arr2);
            Assert.IsTrue(t100.IsSameTree(tree1, tree2));
        }

        [TestMethod()]
        public void IsSameTreeTest_5()
        {
            object[] nodes_arr1 = { 5, 4, 7, 3, null, 2, null, -1, null, 9 };
            object[] nodes_arr2 = { 5, 4, 7, 3, null, 6, null, -1, null, 9, null };
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(nodes_arr1);
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(nodes_arr2);
            Assert.IsFalse(t100.IsSameTree(tree1, tree2));
        }

        [TestMethod()]
        public void IsSameTreeTest_6_AllLeft()
        {
            object[] nodes_arr1 = { 1, 3, null, 5, null, 7 };
            object[] nodes_arr2 = { 1, 3, null, 5, null, 7, null, null };
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(nodes_arr1);
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(nodes_arr2);
            Assert.IsTrue(t100.IsSameTree(tree1, tree2));
        }

        [TestMethod()]
        public void IsSameTreeTest_7_AllRight()
        {
            object[] nodes_arr1 = { 1, null, 2, null, 4, null, 6 };
            object[] nodes_arr2 = { 1, null, 2, null, 4, null, 6 };
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(nodes_arr1);
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(nodes_arr2);
            Assert.IsTrue(t100.IsSameTree(tree1, tree2));
        }
    }
}