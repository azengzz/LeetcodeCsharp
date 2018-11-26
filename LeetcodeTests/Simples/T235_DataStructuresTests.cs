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
    public class T235_DataStructuresTests
    {
        T235_DataStructures t235 = new T235_DataStructures();

        [TestMethod()]
        public void LowestCommonAncestorTest_1()
        {
            object[] nodes = { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            TreeNode p = new TreeNode(3);
            TreeNode q = new TreeNode(5);
            TreeNode expect = new TreeNode(4);

            Assert.IsTrue(expect.val == t235.LowestCommonAncestor(tree, p, q).val);
        }

        [TestMethod()]
        public void LowestCommonAncestorTest_2()
        {
            object[] nodes = { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            TreeNode p = new TreeNode(3);
            TreeNode q = new TreeNode(7);
            TreeNode expect = new TreeNode(6);

            Assert.IsTrue(expect.val == t235.LowestCommonAncestor(tree, p, q).val);
        }

        [TestMethod()]
        public void LowestCommonAncestorTest_3()
        {
            object[] nodes = { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            TreeNode p = new TreeNode(2);
            TreeNode q = new TreeNode(3);
            TreeNode expect = new TreeNode(2);

            Assert.IsTrue(expect.val == t235.LowestCommonAncestor(tree, p, q).val);
        }

    }
}