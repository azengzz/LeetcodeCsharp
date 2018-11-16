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
    public class T101_SymmetricTreeTests
    {
        T101_SymmetricTree t101 = new T101_SymmetricTree();

        [TestMethod()]
        public void IsSymmetricTest_1()
        {
            object[] nodes = { 1, 2, 2, 3, 4, 4, 3 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(t101.IsSymmetric(tree));
        }

        [TestMethod()]
        public void IsSymmetricTest_2()
        {
            object[] nodes = { 1, 2, 2, null, 3, null, 3 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsFalse(t101.IsSymmetric(tree));
        }

        [TestMethod()]
        public void IsSymmetricTest_3()
        {
            object[] nodes = { 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(t101.IsSymmetric(tree));
        }

        [TestMethod()]
        public void IsSymmetricTest_4()
        {
            object[] nodes = null;
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(t101.IsSymmetric(tree));
        }
    }
}