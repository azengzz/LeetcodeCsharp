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

        #region T598 tests : 范围求和

        [TestMethod()]
        public void MaxCountTest_1()
        {
            int[,] ops = { { 2, 2 }, { 3, 3 } };
            Assert.IsTrue(4 == t563.MaxCount(3, 3, ops));
        }

        #endregion

        #region T599 tests : 两个列表的最小索引总和

        [TestMethod()]
        public void FindRestaurantTest_1()
        {
            string[] list1 = { "Shogun", "Tapioca Express", "Burger King", "KFC", "Piatti" };
            string[] list2 = { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" };
            string[] expect = { "Shogun" };
            Assert.IsTrue(CompareHelper.CompareArrays<string>(expect, t563.FindRestaurant(list1, list2)));
        }

        [TestMethod()]
        public void FindRestaurantTest_2()
        {
            string[] list1 = { "Shogun", "Tapioca Express", "Burger King", "Piatti", "KFC" };
            string[] list2 = { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" };
            string[] expect = { "Piatti", "Shogun" };
            Assert.IsTrue(CompareHelper.CompareArrays<string>(expect, t563.FindRestaurant(list1, list2)));
        }

        #endregion

        #region T605 tests : 种花问题

        [TestMethod()]
        public void CanPlaceFlowersTest_1()
        {
            int[] flrs = { 1, 0, 0, 0, 1 };
            Assert.IsTrue(true == t563.CanPlaceFlowers(flrs, 1));
        }

        [TestMethod()]
        public void CanPlaceFlowersTest_2()
        {
            int[] flrs = { 1, 0, 0, 0, 1 };
            Assert.IsTrue(false == t563.CanPlaceFlowers(flrs, 2));
        }

        [TestMethod()]
        public void CanPlaceFlowersTest_3()
        {
            int[] flrs = { 0 };
            Assert.IsTrue(true == t563.CanPlaceFlowers(flrs, 1));
        }

        [TestMethod()]
        public void CanPlaceFlowersTest_4()
        {
            int[] flrs = { 1 };
            Assert.IsTrue(false == t563.CanPlaceFlowers(flrs, 1));
        }

        [TestMethod()]
        public void CanPlaceFlowersTest_5()
        {
            int[] flrs = { 0, 0, 1, 0 };
            Assert.IsTrue(true == t563.CanPlaceFlowers(flrs, 1));
        }

        [TestMethod()]
        public void CanPlaceFlowersTest_6()
        {
            int[] flrs = { 1, 0, 1, 0, 0, 1, 0 };
            Assert.IsTrue(false == t563.CanPlaceFlowers(flrs, 1));
        }

        #endregion

        #region T606 tests : 根据二叉树创建字符串

        [TestMethod()]
        public void Tree2strTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, 4 });
            string expect = "1(2(4))(3)";
            Assert.IsTrue(expect == t563.Tree2str(tree));
        }

        [TestMethod()]
        public void Tree2strTest_2()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, null, 4 });
            string expect = "1(2()(4))(3)";
            Assert.IsTrue(expect == t563.Tree2str(tree));
        }

        [TestMethod()]
        public void Tree2strTest_3()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, 4, null, null, null, 5, null });
            string expect = "1(2(4(5)))(3)";
            Assert.IsTrue(expect == t563.Tree2str(tree));
        }

        [TestMethod()]
        public void Tree2strTest_4()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, 4, 5, 6, 7, null, null, null, 8, null, null, 9 });
            string expect = "1(2(4)(5()(8)))(3(6)(7(9)))";
            Assert.IsTrue(expect == t563.Tree2str(tree));
        }

        #endregion

        #region T617 tests : 合并二叉树

        [TestMethod()]
        public void MergeTreesTest_1()
        {
            TreeNode t1 = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 3, 2, 5, });
            TreeNode t2 = TreeHelper.CreateBinaryTreeByArray(new object[] { 2, 1, 3, null, 4, null, 7 });
            object[] expect = new object[] { 3, 4, 5, 5, 4, null, 7 };
            object[] result = TreeHelper.BreadthFirstTraverse(t563.MergeTrees(t1, t2));
            Assert.IsTrue(CompareHelper.CompareArrays<object>(result, expect));
        }

        [TestMethod()]
        public void MergeTreesTest_2()
        {
            TreeNode t1 = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, null, 3 });
            TreeNode t2 = TreeHelper.CreateBinaryTreeByArray(new object[] { 10, null, 11, null, 12 });
            object[] expect = new object[] { 11, 2, 11, 3, null, null, 12 };
            object[] result = TreeHelper.BreadthFirstTraverse(t563.MergeTrees(t1, t2));
            Assert.IsTrue(CompareHelper.CompareArrays<object>(result, expect));
        }

        #endregion

        #region T628 tests : 在数组中找出三个数使得它们的乘积最大

        [TestMethod()]
        public void MaximumProductTest_1()
        {
            int[] nums = { -1, -3, -5, 0, 2, 4 };
            Assert.IsTrue(60 == t563.MaximumProduct(nums));
        }

        #endregion

        #region T633 tests : 平方数之和

        [TestMethod()]
        public void JudgeSquareSumTest_1()
        {
            Assert.IsTrue(true == t563.JudgeSquareSum(26));
        }

        [TestMethod()]
        public void JudgeSquareSumTest_2()
        {
            Assert.IsTrue(true == t563.JudgeSquareSum(25));
        }

        [TestMethod()]
        public void JudgeSquareSumTest_3()
        {
            Assert.IsTrue(false == t563.JudgeSquareSum(3));
        }

        #endregion

        #region T637 tests : 二叉树的层平均值

        [TestMethod()]
        public void AverageOfLevelsTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 9, 20, null, null, 15, 7 });
            List<double> expect = new   List<double>(){ 3, 14.5, 11 };
            Assert.IsTrue(CompareHelper.CompareList<double>(expect, t563.AverageOfLevels(tree)));
        }

        #endregion
    }
}