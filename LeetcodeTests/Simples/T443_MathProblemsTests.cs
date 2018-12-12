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
    public class T443_MathProblemsTests
    {
        T443_MathProblems t443 = new T443_MathProblems();

        #region T443 tests : 压缩字符串

        [TestMethod()]
        public void CompressTest_1()
        {
            char[] chars = { 'a', 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
            Assert.IsTrue(6 == t443.Compress(chars));
        }

        [TestMethod()]
        public void CompressTest_2()
        {
            char[] chars = { 'a', 'b', 'c', 'b', 'b', 'c', 'c', 'c' };
            Assert.IsTrue(7 == t443.Compress(chars));
        }

        [TestMethod()]
        public void CompressTest_3()
        {
            char[] chars = { 'a', 'b', 'b', 'b', 'c', 'c', 'c', 'c' };
            Assert.IsTrue(5 == t443.Compress(chars));
        }

        [TestMethod()]
        public void CompressTest_4()
        {
            char[] chars = { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'c', 'b', 'c', 'c' };
            Assert.IsTrue(7 == t443.Compress(chars));
        }

        #endregion

        #region T447 tests : 回旋镖的数量

        [TestMethod()]
        public void NumberOfBoomerangsTest_1()
        {
            int[,] a = new int[,] { { 1, 2 }, { 3, 4 }, { -1, 0 } };
            Assert.IsTrue(2 == t443.NumberOfBoomerangs(a));
        }

        [TestMethod()]
        public void NumberOfBoomerangsTest_2()
        {
            int[,] a = new int[,] { { 1, 0 }, { 0, 0 }, { 2, 0 } };
            Assert.IsTrue(2 == t443.NumberOfBoomerangs(a));
        }

        [TestMethod()]
        public void NumberOfBoomerangsTest_3()
        {
            int[,] a = new int[,] { { 0, 0 }, { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            Assert.IsTrue(20 == t443.NumberOfBoomerangs(a));
        }

        #endregion

        #region T448 tests : 找到所有数组中消失的数字

        [TestMethod()]
        public void FindDisappearedNumbersTest_1()
        {
            IList<int> res = t443.FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            IList<int> expect = new List<int> { 5, 6 };
            Assert.IsTrue(CompareHelper.CompareList(res, expect));
        }

        #endregion

        #region T453 tests : 最小移动次数使得数组元素相等

        [TestMethod()]
        public void MinMovesTest_1()
        {
            int[] nums = { 1, 2, 3 };
            Assert.IsTrue(3 == t443.MinMoves(nums));
        }

        [TestMethod()]
        public void MinMovesTest_2()
        {
            int[] nums = { 5, 3, 7, 9, 1 };
            Assert.IsTrue(20 == t443.MinMoves(nums));
        }

        [TestMethod()]
        public void MinMovesTest_3()
        {
            int[] nums = { 1, 3, 5, 9, 16, 85, 142, 20, 60, 9 };
            Assert.IsTrue(340 == t443.MinMoves(nums));
        }

        #endregion

        #region T455 tests : 分发饼干（贪心算法)

        [TestMethod()]
        public void FindContentChildrenTest_1()
        {
            Assert.IsTrue(1 == t443.FindContentChildren(new int[] { 1, 2, 3 }, new int[] { 1, 1 }));
        }

        [TestMethod()]
        public void FindContentChildrenTest_2()
        {
            Assert.IsTrue(2 == t443.FindContentChildren(new int[] { 1, 2 }, new int[] { 1, 2, 3 }));
        }

        #endregion

        #region T458 tests : 可怜的猪

        [TestMethod()]
        public void PoorPigsTest_1()
        {
            Assert.IsTrue(5 == t443.PoorPigs(1000, 15, 60));
        }

        [TestMethod()]
        public void PoorPigsTest_2()
        {
            Assert.IsTrue(0 == t443.PoorPigs(1, 1, 1));
        }

        #endregion

        #region T459 tests : 重复的子字符串

        [TestMethod()]
        public void RepeatedSubstringPatternTest_1()
        {
            Assert.IsTrue(true == t443.RepeatedSubstringPattern("abab"));
        }

        [TestMethod()]
        public void RepeatedSubstringPatternTest_2()
        {
            Assert.IsTrue(true == t443.RepeatedSubstringPattern("abcabcabcabc"));
        }

        [TestMethod()]
        public void RepeatedSubstringPatternTest_3()
        {
            Assert.IsTrue(false == t443.RepeatedSubstringPattern("abcabcabcabca"));
        }

        [TestMethod()]
        public void RepeatedSubstringPatternTest_4()
        {
            Assert.IsTrue(true == t443.RepeatedSubstringPattern("abaababaab"));
        }

        [TestMethod()]
        public void RepeatedSubstringPatternTest_5()
        {
            Assert.IsTrue(false == t443.RepeatedSubstringPattern("a"));
        }

        [TestMethod()]
        public void RepeatedSubstringPatternTest_6()
        {
            Assert.IsTrue(true == t443.RepeatedSubstringPattern("aaa"));
        }

        #endregion

        #region T461 tests : 汉明距离

        [TestMethod()]
        public void HammingDistanceTest_1()
        {
            Assert.IsTrue(2 == t443.HammingDistance(1, 4));
        }

        [TestMethod()]
        public void HammingDistanceTest_2()
        {
            Assert.IsTrue(5 == t443.HammingDistance(1920, 168));
        }

        #endregion

        #region T463 tests : 岛屿的周长

        [TestMethod()]
        public void IslandPerimeterTest_1()
        {
            int[,] grid = { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 } };
            Assert.IsTrue(16 == t443.IslandPerimeter(grid));
        }

        [TestMethod()]
        public void IslandPerimeterTest_2()
        {
            int[,] grid = { { 1, 0 } };
            Assert.IsTrue(4 == t443.IslandPerimeter(grid));
        }

        #endregion

        #region T475 tests 供暖器的最小半径

        [TestMethod()]
        public void FindRadiusTest_1()
        {
            int[] houses = { 1, 2, 3 };
            int[] heaters = { 2 };
            Assert.IsTrue(1 == t443.FindRadius(houses, heaters));
        }

        [TestMethod()]
        public void FindRadiusTest_2()
        {
            int[] houses = { 1, 2, 3, 4 };
            int[] heaters = { 1, 4 };
            Assert.IsTrue(1 == t443.FindRadius(houses, heaters));
        }

        [TestMethod()]
        public void FindRadiusTest_3()
        {
            int[] houses = { 3, 4, 5, 6, 7, 8, 9, 13, 20 };
            int[] heaters = { 9, 14 };
            Assert.IsTrue(6 == t443.FindRadius(houses, heaters));
        }

        [TestMethod()]
        public void FindRadiusTest_4()
        {
            int[] houses = { 1, 5 };
            int[] heaters = { 2 };
            Assert.IsTrue(3 == t443.FindRadius(houses, heaters));
        }

        [TestMethod()]
        public void FindRadiusTest_5()
        {
            int[] houses = { 282475249, 622650073, 984943658, 144108930, 470211272, 101027544, 457850878, 458777923 };
            int[] heaters = { 823564440, 115438165, 784484492, 74243042, 114807987, 137522503, 441282327, 16531729, 823378840, 143542612 };
            Assert.IsTrue(161834419 == t443.FindRadius(houses, heaters));
        }

        #endregion

        #region T476 tests : 求数字的补数

        [TestMethod()]
        public void FindComplementTest_1()
        {
            Assert.IsTrue(2 == t443.FindComplement(5));
        }

        [TestMethod()]
        public void FindComplementTest_2()
        {
            Assert.IsTrue(110 == t443.FindComplement(145));
        }


        #endregion

        #region T479 tests 最大回文数乘积

        [TestMethod()]
        public void LargestPalindromeTest_1()
        {
            Assert.IsTrue(987 == t443.LargestPalindrome(2));
        }

        [TestMethod()]
        public void LargestPalindromeTest_2()
        {
            Assert.IsTrue(597 == t443.LargestPalindrome(4));
        }

        [TestMethod()]
        public void LargestPalindromeTest_3()
        {
            Assert.IsTrue(877 == t443.LargestPalindrome(7));
        }

        #endregion

        #region T482 tests 密钥格式化

        [TestMethod()]
        public void LicenseKeyFormattingTest_1()
        {
            string expect = "5F3Z-2E9W";
            Assert.IsTrue(expect == t443.LicenseKeyFormatting("5F3Z-2e-9-w", 4));
        }

        [TestMethod()]
        public void LicenseKeyFormattingTest_2()
        {
            string expect = "5F3Z2E9W";
            Assert.IsTrue(expect == t443.LicenseKeyFormatting("5F3Z-2e-9-w", 9));
        }

        [TestMethod()]
        public void LicenseKeyFormattingTest_3()
        {
            string expect = "M-5F-3Z-2E-9W";
            Assert.IsTrue(expect == t443.LicenseKeyFormatting("m-5F3Z-2e-9-w", 2));
        }

        [TestMethod()]
        public void LicenseKeyFormattingTest_4()
        {
            string expect = "AA-AA";
            Assert.IsTrue(expect == t443.LicenseKeyFormatting("-----a-a-a-a------", 2));
        }

        [TestMethod()]
        public void LicenseKeyFormattingTest_5()
        {
            string expect = "";
            Assert.IsTrue(expect == t443.LicenseKeyFormatting("--------", 2));
        }

        #endregion
    }
}