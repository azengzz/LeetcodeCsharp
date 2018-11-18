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
    public class T104_BinaryTreeDepthTests
    {
        T104_BinaryTreeDepth t104 = new T104_BinaryTreeDepth();

        [TestMethod()]
        public void MaxDepthTest_1()
        {
            object[] nodes = { 3, 9, 20, null, null, 15, 7 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 3;
            int result = t104.MaxDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MaxDepthTest_2()
        {
            object[] nodes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 4;
            int result = t104.MaxDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MaxDepthTest_3()
        {
            object[] nodes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, null, null, null, null, null, null, null, null, null, null, 11 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 5;
            int result = t104.MaxDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MaxDepthTest_4()
        {
            object[] nodes = { 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 1;
            int result = t104.MaxDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MaxDepthTest_5()
        {
            object[] nodes = null;
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 0;
            int result = t104.MaxDepth(tree);
            Assert.IsTrue(expect == result);
        }

        //--------------------------------

        [TestMethod()]
        public void MinDepthTest_1()
        {
            object[] nodes = { 3, 9, 20, null, null, 15, 7 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 2;
            int result = t104.MinDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MinDepthTest_2()
        {
            object[] nodes = { 3, null, 20, null, 7 };   //只有单侧有值的二叉树
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 3;
            int result = t104.MinDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MinDepthTest_3()
        {
            object[] nodes = { 1, 2, 2, 3, null, null, 3, 4, null, null, 4 };    //对称树
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 4;
            int result = t104.MinDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MinDepthTest_4()
        {
            object[] nodes = { 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 1;
            int result = t104.MinDepth(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void MinDepthTest_5()
        {
            object[] nodes = null;
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            int expect = 0;
            int result = t104.MinDepth(tree);
            Assert.IsTrue(expect == result);
        }

        //--------------------------------

        [TestMethod()]
        public void HasPathSumTest_1()
        {
            object[] nodes = { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(true == t104.HasPathSum(tree, 22));
        }

        [TestMethod()]
        public void HasPathSumTest_2()
        {
            object[] nodes = { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(false == t104.HasPathSum(tree, 23));
        }

        [TestMethod()]
        public void HasPathSumTest_3()
        {
            object[] nodes = { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(true == t104.HasPathSum(tree, 26));
        }

        [TestMethod()]
        public void HasPathSumTest_4()
        {
            object[] nodes = { 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(true == t104.HasPathSum(tree, 5));
        }

        [TestMethod()]
        public void HasPathSumTest_5()
        {
            object[] nodes = { 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(false == t104.HasPathSum(tree, 6));
        }

        [TestMethod()]
        public void HasPathSumTest_6_emptyTree()
        {
            object[] nodes = null;
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(false == t104.HasPathSum(tree, 0));
        }

        [TestMethod()]
        public void HasPathSumTest_7()
        {
            object[] nodes = { 1, 2 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(false == t104.HasPathSum(tree, 1));
        }

        [TestMethod()]
        public void HasPathSumTest_8()    //在到达叶子之前，和已经和目标相等
        {
            object[] nodes = { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(false == t104.HasPathSum(tree, 20));
        }

        [TestMethod()]
        public void HasPathSumTest_9()    //在到达叶子之前，和已经和目标相等，但是其他路径有根到叶子的和刚好和目标相等
        {
            object[] nodes = { 5, 4, 8, 9, null, 13, 4, 7, 2, null, null, null, 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(true == t104.HasPathSum(tree, 18));
        }

        [TestMethod()]
        public void HasPathSumTest_10()   
        {
            object[] nodes = { 5, 4, 8, 9, null, 13, 4, 7, null, null, null, null, 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(true == t104.HasPathSum(tree, 18));
        }
    }
}