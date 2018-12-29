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
    public class T867_ProblemsTests
    {
        T867_Problems t867 = new T867_Problems();

        #region T867 tests : 转置矩阵

        [TestMethod()]
        public void TransposeTest_1()
        {
            int[][] A = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            int[] T1 = { 1, 4, 7 };
            int[] T2 = { 2, 5, 8 };
            int[] T3 = { 3, 6, 9 };
            int[][] T = t867.Transpose(A);
            Assert.IsTrue(CompareHelper.CompareArrays(T1, T[0]));
            Assert.IsTrue(CompareHelper.CompareArrays(T2, T[1]));
            Assert.IsTrue(CompareHelper.CompareArrays(T3, T[2]));
        }

        [TestMethod()]
        public void TransposeTest_2()
        {
            int[][] A = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };
            int[] T1 = { 1, 4 };
            int[] T2 = { 2, 5 };
            int[] T3 = { 3, 6 };
            int[][] T = t867.Transpose(A);
            Assert.IsTrue(CompareHelper.CompareArrays(T1, T[0]));
            Assert.IsTrue(CompareHelper.CompareArrays(T2, T[1]));
            Assert.IsTrue(CompareHelper.CompareArrays(T3, T[2]));
        }

        #endregion

        #region T868 tests : 二进制间距

        [TestMethod()]
        public void BinaryGapTest_1()
        {
            Assert.IsTrue(2 == t867.BinaryGap(22));
        }

        [TestMethod()]
        public void BinaryGapTest_2()
        {
            Assert.IsTrue(2 == t867.BinaryGap(5));
        }

        [TestMethod()]
        public void BinaryGapTest_3()
        {
            Assert.IsTrue(1 == t867.BinaryGap(6));
        }

        [TestMethod()]
        public void BinaryGapTest_4()
        {
            Assert.IsTrue(0 == t867.BinaryGap(8));
        }

        [TestMethod()]
        public void BinaryGapTest_5()
        {
            Assert.IsTrue(16 == t867.BinaryGap(65537));
        }

        #endregion

        #region T872 tests : 叶子相似的树

        [TestMethod()]
        public void LeafSimilarTest_1()
        {
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 });
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8 });
            Assert.IsTrue(true == t867.LeafSimilar(tree1, tree2));
        }

        [TestMethod()]
        public void LeafSimilarTest_2()
        {
            TreeNode tree1 = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4, 11 });
            TreeNode tree2 = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8 });
            Assert.IsTrue(false == t867.LeafSimilar(tree1, tree2));
        }

        #endregion

        #region T876 tests : 链表的中间节点

        [TestMethod()]
        public void MiddleNodeTest_1()
        {
            int[] nodes = { 1, 2, 3, 4, 5 };
            ListNode list = ListNodeHelper.CreateLinkedListByArray(nodes);
            Assert.IsTrue(3 == t867.MiddleNode(list).val);
        }

        [TestMethod()]
        public void MiddleNodeTest_2()
        {
            int[] nodes = { 1, 2, 3, 4, 5, 6 };
            ListNode list = ListNodeHelper.CreateLinkedListByArray(nodes);
            Assert.IsTrue(4 == t867.MiddleNode(list).val);
        }

        #endregion

        #region T883 tests : 三维形体投影面积

        [TestMethod()]
        public void ProjectionAreaTest_1()
        {
            Assert.IsTrue(5 == t867.ProjectionArea(new int[][] { new int[] { 2 } }));
        }

        [TestMethod()]
        public void ProjectionAreaTest_2()
        {
            int[][] grid = { new int[] { 1, 2 }, new int[] { 3, 4 } };
            Assert.IsTrue(17 == t867.ProjectionArea(grid));
        }

        [TestMethod()]
        public void ProjectionAreaTest_3()
        {
            int[][] grid = { new int[] { 1, 0 }, new int[] { 0, 2 } };
            Assert.IsTrue(8 == t867.ProjectionArea(grid));
        }

        [TestMethod()]
        public void ProjectionAreaTest_4()
        {
            int[][] grid = { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } };
            Assert.IsTrue(14 == t867.ProjectionArea(grid));
        }

        [TestMethod()]
        public void ProjectionAreaTest_5()
        {
            int[][] grid = { new int[] { 2, 2, 2 }, new int[] { 2, 1, 2 }, new int[] { 2, 2, 2 } };
            Assert.IsTrue(21 == t867.ProjectionArea(grid));
        }

        #endregion

        #region T884 tests : 两句话中不常见的单词

        [TestMethod()]
        public void UncommonFromSentencesTest_1()
        {
            string A = "this apple is sweet";
            string B = "this apple is sour";
            string[] expect = { "sweet", "sour" };
            Assert.IsTrue(CompareHelper.CompareArrays<string>(expect, t867.UncommonFromSentences(A, B)));
        }

        [TestMethod()]
        public void UncommonFromSentencesTest_2()
        {
            string A = "apple apple";
            string B = "banana";
            string[] expect = { "banana" };
            Assert.IsTrue(CompareHelper.CompareArrays<string>(expect, t867.UncommonFromSentences(A, B)));
        }

        #endregion

        #region T888 tests : 公平的糖果交换

        [TestMethod()]
        public void FairCandySwapTest_1()
        {
            int[] A = { 1, 1 }, B = { 2, 2 };
            int[] expect = { 1, 2 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t867.FairCandySwap(A, B)));
        }

        [TestMethod()]
        public void FairCandySwapTest_2()
        {
            int[] A = { 1, 2 }, B = { 2, 3 };
            int[] expect = { 1, 2 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t867.FairCandySwap(A, B)));
        }

        [TestMethod()]
        public void FairCandySwapTest_3()
        {
            int[] A = { 2 }, B = { 1, 3 };
            int[] expect = { 2, 3 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t867.FairCandySwap(A, B)));
        }

        [TestMethod()]
        public void FairCandySwapTest_4()
        {
            int[] A = { 1, 2, 5 }, B = { 2, 4 };
            int[] expect = { 5, 4 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t867.FairCandySwap(A, B)));
        }

        #endregion

        #region T892 tests : 三维形体的表面积

        [TestMethod()]
        public void SurfaceAreaTest_1()
        {
            int[][] grid = new int[][] { new int[] { 2, 2, 2 }, new int[] { 2, 1, 2 }, new int[] { 2, 2, 2 } };
            Assert.IsTrue(46 == t867.SurfaceArea(grid));
        }

        [TestMethod()]
        public void SurfaceAreaTest_2()
        {
            int[][] grid = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
            Assert.IsTrue(34 == t867.SurfaceArea(grid));
        }

        #endregion

        #region T893 tests : 特殊等价字符串组

        [TestMethod()]
        public void NumSpecialEquivGroupsTest_1()
        {
            string[] A = { "abc", "acb", "bac", "bca", "cab", "cba" };
            Assert.IsTrue(3 == t867.NumSpecialEquivGroups(A));
        }

        #endregion

        #region T896 tests : 单调数列

        [TestMethod()]
        public void IsMonotonicTest_1()
        {
            int[] A = { 1, 2, 2, 3 };
            Assert.IsTrue(true == t867.IsMonotonic(A));
        }

        [TestMethod()]
        public void IsMonotonicTest_2()
        {
            int[] A = { 1, 1, 1 };
            Assert.IsTrue(true == t867.IsMonotonic(A));
        }

        #endregion

        #region T897 tests : 递增顺序查询树

        [TestMethod()]
        public void IncreasingBSTTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 5, 3, 6, 2, 4, null, 8, 1, null, null, null, 7, 9 });
            Assert.IsTrue(1 == t867.IncreasingBST(tree).val);
        }

        #endregion
    }
}