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

        #region T905 tests : 按奇偶排序的数组

        [TestMethod()]
        public void SortArrayByParityTest_1()
        {
            int[] expect = { 2, 4, 3, 1 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t867.SortArrayByParity(new int[] { 3, 1, 2, 4 })));
        }

        #endregion

        #region T914 tests : 卡牌分组

        [TestMethod()]
        public void HasGroupsSizeXTest_1()
        {
            int[] deck = { 1, 2, 3, 4, 4, 3, 2, 1 };
            Assert.IsTrue(true == t867.HasGroupsSizeX(deck));
        }

        [TestMethod()]
        public void HasGroupsSizeXTest_2()
        {
            int[] deck = { 1, 1, 1, 2, 2, 2, 3, 3 };
            Assert.IsTrue(false == t867.HasGroupsSizeX(deck));
        }

        [TestMethod()]
        public void HasGroupsSizeXTest_3()
        {
            int[] deck = { 1 };
            Assert.IsTrue(false == t867.HasGroupsSizeX(deck));
        }

        [TestMethod()]
        public void HasGroupsSizeXTest_4()
        {
            int[] deck = { 1, 1, 2, 2, 2, 2 };
            Assert.IsTrue(true == t867.HasGroupsSizeX(deck));
        }

        [TestMethod()]
        public void HasGroupsSizeXTest_5()
        {
            int[] deck = { };
            Assert.IsTrue(false == t867.HasGroupsSizeX(deck));
        }

        #endregion

        #region T917 tests : 仅仅反转字母

        [TestMethod()]
        public void ReverseOnlyLettersTest_1()
        {
            string expect = "j-Ih-gfE-dCba";
            Assert.IsTrue(expect == t867.ReverseOnlyLetters("a-bC-dEf-ghIj"));
        }

        [TestMethod()]
        public void ReverseOnlyLettersTest_2()
        {
            string expect = "Test1ng-Leet=code-Q!";
            Assert.IsTrue(expect == t867.ReverseOnlyLetters("Qedo1ct-eeLg=ntse-T!"));
        }


        #endregion

        #region T922 tests : 按奇偶性排序数组

        [TestMethod()]
        public void SortArrayByParityIITest_1()
        {
            int[] expect = { 4, 5, 2, 7 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t867.SortArrayByParityII(new int[] { 4, 2, 5, 7 })));
        }

        [TestMethod()]
        public void SortArrayByParityIITest_2()
        {
            int[] expect = { 2, 1, 4, 3, 6, 5, 8, 7 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t867.SortArrayByParityII(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })));
        }

        #endregion

        #region T925 tests : 长按键入

        [TestMethod()]
        public void IsLongPressedNameTest_1()
        {
            string name = "alex";
            string typed = "aaleex";
            Assert.IsTrue(true == t867.IsLongPressedName(name, typed));
        }

        [TestMethod()]
        public void IsLongPressedNameTest_2()
        {
            string name = "saeed";
            string typed = "ssaaedd";
            Assert.IsTrue(false == t867.IsLongPressedName(name, typed));
        }

        [TestMethod()]
        public void IsLongPressedNameTest_3()
        {
            string name = "plpkoh";
            string typed = "plppkkh";
            Assert.IsTrue(false == t867.IsLongPressedName(name, typed));
        }

        [TestMethod()]
        public void IsLongPressedNameTest_4()
        {
            string name = "pyplrz";
            string typed = "ppyypllr";
            Assert.IsTrue(false == t867.IsLongPressedName(name, typed));
        }

        #endregion

        #region T929 tests : 独特的电子邮件地址

        [TestMethod()]
        public void NumUniqueEmailsTest_1()
        {
            string[] emails = { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            Assert.IsTrue(2 == t867.NumUniqueEmails(emails));
        }

        #endregion

        #region T937 tests : 重新排列日志文件

        [TestMethod()]
        public void ReorderLogFilesTest_1()
        {
            string[] logs = { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" };
            string[] expect = { "g1 act car", "a8 act zoo", "ab1 off key dog", "a1 9 2 3 1", "zo4 4 7" };
            Assert.IsTrue(CompareHelper.CompareArrays<string>(expect, t867.ReorderLogFiles(logs)));
        }

        #endregion

        #region T941 tests : 有效的山脉数组

        [TestMethod()]
        public void ValidMountainArrayTest_1()
        {
            int[] A = { 1, 2, 4, 3, 1 };
            Assert.IsTrue(true == t867.ValidMountainArray(A));
        }

        [TestMethod()]
        public void ValidMountainArrayTest_2()
        {
            int[] A = { 1, 2, 3, 4 };
            Assert.IsTrue(false == t867.ValidMountainArray(A));
        }

        [TestMethod()]
        public void ValidMountainArrayTest_3()
        {
            int[] A = { 4, 3, 2, 1 };
            Assert.IsTrue(false == t867.ValidMountainArray(A));
        }

        [TestMethod()]
        public void ValidMountainArrayTest_4()
        {
            int[] A = { 1, 2, 3, 3, 2, 1 };
            Assert.IsTrue(false == t867.ValidMountainArray(A));
        }

        #endregion

        #region T944 tests : 删除造序

        [TestMethod()]
        public void MinDeletionSizeTest_1()
        {
            string[] A = { "cba", "daf", "ghi" };
            Assert.IsTrue(1 == t867.MinDeletionSize(A));
        }

        [TestMethod()]
        public void MinDeletionSizeTest_2()
        {
            string[] A = { "a", "b" };
            Assert.IsTrue(0 == t867.MinDeletionSize(A));
        }

        [TestMethod()]
        public void MinDeletionSizeTest_3()
        {
            string[] A = { "zyx", "wvu", "tsr" };
            Assert.IsTrue(3 == t867.MinDeletionSize(A));
        }

        [TestMethod()]
        public void MinDeletionSizeTest_4()
        {
            string[] A = { "rrjk", "furt", "guzm" };
            Assert.IsTrue(2 == t867.MinDeletionSize(A));
        }

        #endregion

        #region T949 tests : 给定数字能组成的最大时间

        [TestMethod()]
        public void LargestTimeFromDigitsTest_1()
        {
            int[] A = { 1, 2, 3, 4 };
            Assert.IsTrue("23:41" == t867.LargestTimeFromDigits(A));
        }

        [TestMethod()]
        public void LargestTimeFromDigitsTest_2()
        {
            int[] A = { 5, 5, 5, 5 };
            Assert.IsTrue("" == t867.LargestTimeFromDigits(A));
        }

        [TestMethod()]
        public void LargestTimeFromDigitsTest_3()
        {
            int[] A = { 0, 0, 0, 0 };
            Assert.IsTrue("00:00" == t867.LargestTimeFromDigits(A));
        }

        #endregion

        #region T953 tests : 验证外星语词典

        [TestMethod()]
        public void IsAlienSortedTest_1()
        {
            string[] words = { "hello", "leetcode" };
            string order = "hlabcdefgijkmnopqrstuvwxyz";
            Assert.IsTrue(true == t867.IsAlienSorted(words, order));
        }

        [TestMethod()]
        public void IsAlienSortedTest_2()
        {
            string[] words = { "word", "world", "row" };
            string order = "worldabcefghijkmnpqstuvxyz";
            Assert.IsTrue(false == t867.IsAlienSorted(words, order));
        }

        [TestMethod()]
        public void IsAlienSortedTest_3()
        {
            string[] words = { "fxasxpc", "dfbdrifhp", "nwzgs", "cmwqriv", "ebulyfyve", "miracx", "sxckdwzv", "dtijzluhts", "wwbmnge", "qmjwymmyox" };
            string order = "zkgwaverfimqxbnctdplsjyohu";
            Assert.IsTrue(false == t867.IsAlienSorted(words, order));
        }

        #endregion
    }
}