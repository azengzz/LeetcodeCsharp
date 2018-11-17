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
            object[] nodes = { 3,null,20,null,7 };   //只有单侧有值的二叉树
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
    }
}