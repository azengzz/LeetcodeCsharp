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
    public class T563_ProblemsTests
    {
        T563_Problems t563 = new T563_Problems();

        #region T563 tests : 求二叉树的坡度

        [TestMethod()]
        public void FindTiltTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.IsTrue(7 == t563.FindTilt(tree));
        }

        [TestMethod()]
        public void FindTiltTest_2()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, null, null, 4, 5, null, null, 6, null, null, 7 });
            Assert.IsTrue(57 == t563.FindTilt(tree));
        }

        #endregion

        #region T566 tests : 重塑矩阵

        [TestMethod()]
        public void MatrixReshapeTest_1()
        {
            int[,] nums = { { 1, 2 }, { 3, 4 } };
            int[,] expect = { { 1, 2, 3, 4 } };
            int[,] res = t563.MatrixReshape(nums, 1, 4);
            for (int i = 0; i < 4; i++)
            {
                if (expect[0, i] != res[0, i]) Assert.Fail();
            }
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MatrixReshapeTest_2()
        {
            int[,] nums = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] expect = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] res = t563.MatrixReshape(nums, 3, 2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                    if (expect[i, j] != res[i, j]) Assert.Fail();
            }
            Assert.IsTrue(true);
        }

        #endregion

        #region T572 tests : 问一棵树是否是另一棵树的子树

        [TestMethod()]
        public void IsSubtreeTest_1()
        {
            TreeNode stree = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 4, 5, 1, 2 });
            TreeNode ttree = TreeHelper.CreateBinaryTreeByArray(new object[] { 4, 1, 2 });
            Assert.IsTrue(true == t563.IsSubtree(stree, ttree));
        }

        [TestMethod()]
        public void IsSubtreeTest_2()
        {
            TreeNode stree = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 4, 5, 1, 2, null, null, null, null, 0, null });
            TreeNode ttree = TreeHelper.CreateBinaryTreeByArray(new object[] { 4, 1, 2 });
            Assert.IsTrue(false == t563.IsSubtree(stree, ttree));
        }

        #endregion

        #region T575 tests : 分糖果

        [TestMethod()]
        public void DistributeCandiesTest_1()
        {
            int[] candies = { 1, 1, 2, 2, 3, 3 };
            Assert.IsTrue(3 == t563.DistributeCandies(candies));
        }

        [TestMethod()]
        public void DistributeCandiesTest_2()
        {
            int[] candies = { 1, 1, 2, 3 };
            Assert.IsTrue(2 == t563.DistributeCandies(candies));
        }

        #endregion

        #region T581 tests : 最短无序连续子数组的长度

        [TestMethod()]
        public void FindUnsortedSubarrayTest_1()
        {
            int[] nums = { 2, 6, 4, 8, 10, 9, 15 };
            Assert.IsTrue(5 == t563.FindUnsortedSubarray(nums));
        }

        [TestMethod()]
        public void FindUnsortedSubarrayTest_2()
        {
            int[] nums = { 6, 5, 4, 3, 2, 1 };
            Assert.IsTrue(6 == t563.FindUnsortedSubarray(nums));
        }

        [TestMethod()]
        public void FindUnsortedSubarrayTest_3()
        {
            int[] nums = { 1, 2, 3, 3, 3 };
            Assert.IsTrue(0 == t563.FindUnsortedSubarray(nums));
        }

        [TestMethod()]
        public void FindUnsortedSubarrayTest_4()
        {
            int[] nums = { 1, 3, 2, 2, 2, 4, 6, 5, 5, 5, 5 };
            Assert.IsTrue(10 == t563.FindUnsortedSubarray(nums));
        }

        [TestMethod()]
        public void FindUnsortedSubarrayTest_5()
        {
            int[] nums = { 1, 3, 2, 3, 3 };
            Assert.IsTrue(2 == t563.FindUnsortedSubarray(nums));
        }

        #endregion

        #region T594 tests : 最长和谐子序列

        [TestMethod()]
        public void FindLHSTest_1()
        {
            int[] nums = { 1, 3, 2, 2, 5, 2, 3, 7 };
            Assert.IsTrue(5 == t563.FindLHS(nums));
        }

        [TestMethod()]
        public void FindLHSTest_2()
        {
            int[] nums = { 1, 1, 1, 1 };
            Assert.IsTrue(0 == t563.FindLHS(nums));
        }

        [TestMethod()]
        public void FindLHSTest_3()
        {
            int[] nums = { 1, 1, 1, 1, 4 };
            Assert.IsTrue(0 == t563.FindLHS(nums));
        }

        #endregion
    }
}