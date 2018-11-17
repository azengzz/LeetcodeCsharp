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
    public class T110_BalancedBinaryTreeTests
    {
        T110_BalancedBinaryTree t100 = new T110_BalancedBinaryTree();

        [TestMethod()]
        public void IsBalancedTest_1()    //根节点的左右子树高度一样，但是子树内部高度不平衡了
        {
            object[] origin = { 1, 2, 2, 3, null, null, 3, 4, null, null, 4 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(origin);
            bool expect = false;
            bool result = t100.IsBalanced(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void IsBalancedTest_2()
        {
            object[] origin = { 3, 9, 20, null, null, 15, 7 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(origin);
            bool expect = true;
            bool result = t100.IsBalanced(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void IsBalancedTest_3()
        {
            object[] origin = { 1, 2, 2, 3, 3, null, null, 4, 4 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(origin);
            bool expect = false;
            bool result = t100.IsBalanced(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void IsBalancedTest_4()
        {
            object[] origin = { 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(origin);
            bool expect = true;
            bool result = t100.IsBalanced(tree);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void IsBalancedTest_5()
        {
            object[] origin = null;
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(origin);
            bool expect = true;
            bool result = t100.IsBalanced(tree);
            Assert.IsTrue(expect == result);
        }
    }
}