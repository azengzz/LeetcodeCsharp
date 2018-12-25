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
    public class T733_ProblemsTests
    {
        T733_Problems t773 = new T733_Problems();

        #region T733 tests : 图像渲染        

        [TestMethod()]
        public void FloodFillTest_1()
        {
            int[,] image = new int[,] { { 1, 1, 1 }, { 1, 1, 0 }, { 1, 0, 1 } };
            int[,] expect = new int[,] { { 2, 2, 2 }, { 2, 2, 0 }, { 2, 0, 1 } };
            Assert.IsTrue(CompareHelper.CompareTwoDimensionalArray<int>(expect, t773.FloodFill(image, 1, 1, 2)));
        }

        [TestMethod()]
        public void FloodFillTest_2()
        {
            int[,] image = new int[,] { { 0, 0, 0 }, { 0, 1, 1 } };
            int[,] expect = new int[,] { { 0, 0, 0 }, { 0, 1, 1 } };
            Assert.IsTrue(CompareHelper.CompareTwoDimensionalArray<int>(expect, t773.FloodFill(image, 1, 1, 1)));
        }

        #endregion

        #region T746 tests : 使用最小花费爬楼梯

        [TestMethod()]
        public void MinCostClimbingStairsTest_1()
        {
            int[] cost = { 10, 15, 20 };
            Assert.IsTrue(15 == t773.MinCostClimbingStairs(cost));
        }

        [TestMethod()]
        public void MinCostClimbingStairsTest_2()
        {
            int[] cost = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            Assert.IsTrue(6 == t773.MinCostClimbingStairs(cost));
        }

        #endregion

        #region T748 tests : 最短完整词

        [TestMethod()]
        public void ShortestCompletingWordTest_1()
        {
            string licensePlate = "1s3 PSt";
            string[] words = new string[] { "step", "steps", "stripe", "stepple" };
            Assert.IsTrue("steps" == t773.ShortestCompletingWord(licensePlate, words));
        }

        [TestMethod()]
        public void ShortestCompletingWordTest_2()
        {
            string licensePlate = "1s3 456";
            string[] words = new string[] { "looks", "pest", "stew", "show" };
            Assert.IsTrue("pest" == t773.ShortestCompletingWord(licensePlate, words));
        }

        [TestMethod()]
        public void ShortestCompletingWordTest_3()
        {
            string licensePlate = "GrC8950";
            string[] words = new string[] { "measure", "other", "every", "base", "according", "level", "meeting", "none", "marriage", "rest" };
            Assert.IsTrue("according" == t773.ShortestCompletingWord(licensePlate, words));
        }

        #endregion

        #region T754 tests : 达到终点的数字

        [TestMethod()]
        public void ReachNumberTest_1()
        {
            Assert.IsTrue(5 == t773.ReachNumber(11));
        }

        #endregion

        #region T762 tests : 二级制表示中质数个计算置位

        [TestMethod()]
        public void CountPrimeSetBitsTest_1()
        {
            Assert.IsTrue(4 == t773.CountPrimeSetBits(6, 10));
        }

        [TestMethod()]
        public void CountPrimeSetBitsTest_2()
        {
            Assert.IsTrue(5 == t773.CountPrimeSetBits(10, 15));
        }

        #endregion

        #region T766 tests : 托普利茨矩阵

        [TestMethod()]
        public void IsToeplitzMatrixTest_1()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            Assert.IsTrue(true == t773.IsToeplitzMatrix(matrix));
        }

        [TestMethod()]
        public void IsToeplitzMatrixTest_2()
        {
            int[,] matrix = { { 1, 2 }, { 2, 2 } };
            Assert.IsTrue(false == t773.IsToeplitzMatrix(matrix));
        }

        #endregion

        #region T771 tests : 宝石与石头

        [TestMethod()]
        public void NumJewelsInStonesTest_1()
        {
            Assert.IsTrue(3 == t773.NumJewelsInStones("aA", "aAAbbbb"));
        }

        [TestMethod()]
        public void NumJewelsInStonesTest_2()
        {
            Assert.IsTrue(0 == t773.NumJewelsInStones("z", "ZZ"));
        }

        #endregion

        #region T783 tests : 二叉搜索树节点最小距离

        [TestMethod()]
        public void MinDiffInBSTTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 4, 2, 6, 1, 3 });
            Assert.IsTrue(1 == t773.MinDiffInBST(tree));
        }

        #endregion

        #region T784 tests : 字母大小写全排列

        [TestMethod()]
        public void LetterCasePermutationTest_1()
        {
            List<string> expect = new List<string> { "a1b2", "a1B2", "A1b2", "A1B2" };
            List<string> result = t773.LetterCasePermutation("a1b2").ToList<string>();
            Assert.IsTrue(CompareHelper.CompareList<string>(expect, result));
        }

        [TestMethod()]
        public void LetterCasePermutationTest_2()
        {
            List<string> expect = new List<string> { "3z4", "3Z4" };
            List<string> result = t773.LetterCasePermutation("3z4").ToList<string>();
            Assert.IsTrue(CompareHelper.CompareList<string>(expect, result));
        }

        [TestMethod()]
        public void LetterCasePermutationTest_3()
        {
            List<string> expect = new List<string> { "12345" };
            List<string> result = t773.LetterCasePermutation("12345").ToList<string>();
            Assert.IsTrue(CompareHelper.CompareList<string>(expect, result));
        }

        #endregion

        #region T788 tests : 旋转数字

        [TestMethod()]
        public void RotatedDigitsTest_1()
        {
            Assert.IsTrue(4 == t773.RotatedDigits(10));
        }

        [TestMethod()]
        public void RotatedDigitsTest_2()
        {
            Assert.IsTrue(2320 == t773.RotatedDigits(10000));
        }

        #endregion

        #region T796 tests : 旋转字符串

        [TestMethod()]
        public void RotateStringTest_1()
        {
            Assert.IsTrue(true == t773.RotateString("abcde", "cdeab"));
        }

        [TestMethod()]
        public void RotateStringTest_2()
        {
            Assert.IsTrue(false == t773.RotateString("abcde", "abced"));
        }

        #endregion

        #region T804 tests : 唯一摩尔斯密码词

        [TestMethod()]
        public void UniqueMorseRepresentationsTest_1()
        {
            Assert.IsTrue(2 == t773.UniqueMorseRepresentations(new string[] { "gin", "zen", "gig", "msg" }));
        }

        #endregion

        #region T806 tests : 写字符串需要的行数

        [TestMethod()]
        public void NumberOfLinesTest_1()
        {
            int[] width = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string S = "abcdefghijklmnopqrstuvwxyz";
            int[] expect = { 3, 60 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t773.NumberOfLines(width, S)));
        }

        [TestMethod()]
        public void NumberOfLinesTest_2()
        {
            int[] width = { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string S = "bbbcccdddaaa";
            int[] expect = { 2, 4 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t773.NumberOfLines(width, S)));
        }

        #endregion

        #region T811 tests : 子域名访问计数

        [TestMethod()]
        public void SubdomainVisitsTest_1()
        {
            string[] domains = { "9001 discuss.leetcode.com" };
            List<string> expect = new List<string> { "9001 com", "9001 leetcode.com", "9001 discuss.leetcode.com" };
            List<string> result = t773.SubdomainVisits(domains).ToList();
            Assert.IsTrue(CompareHelper.CompareList<string>(expect, result));
        }

        [TestMethod()]
        public void SubdomainVisitsTest_2()
        {
            string[] domains = { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" };
            List<string> expect = new List<string>
            { "951 com","901 mail.com","900 google.mail.com","50 yahoo.com","1 intel.mail.com","5 org","5 wiki.org" };
            List<string> result = t773.SubdomainVisits(domains).ToList();
            Assert.IsTrue(CompareHelper.CompareList<string>(expect, result));
        }

        #endregion
    }
}