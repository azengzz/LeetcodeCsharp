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
    public class T404_MathProblemsTests
    {
        T404_MathProblems t404 = new T404_MathProblems();

        #region T404 tests : 求一棵给定二叉树的左叶子之和

        [TestMethod()]
        public void SumOfLeftLeavesTest_1()
        {
            object[] nodes = { 3, 9, 20, null, null, 15, 7 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(24 == t404.SumOfLeftLeaves(tree));
        }

        [TestMethod()]
        public void SumOfLeftLeavesTest_2()
        {
            object[] nodes = { 3 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(0 == t404.SumOfLeftLeaves(tree));
        }

        [TestMethod()]
        public void SumOfLeftLeavesTest_3()
        {
            object[] nodes = { };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(0 == t404.SumOfLeftLeaves(tree));
        }

        [TestMethod()]
        public void SumOfLeftLeavesTest_4()
        {
            object[] nodes = { 1, null, 2, null, 3, null, 4 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            Assert.IsTrue(0 == t404.SumOfLeftLeaves(tree));
        }

        #endregion

        #region T405 tests : 十进制有符号整数转换为十六进制数

        [TestMethod()]
        public void ToHexTest_1()
        {
            Assert.IsTrue("ffffffff" == t404.ToHex(-1));
        }

        [TestMethod()]
        public void ToHexTest_2()
        {
            Assert.IsTrue("0" == t404.ToHex(0));
        }

        [TestMethod()]
        public void ToHexTest_3()
        {
            Assert.IsTrue("1a" == t404.ToHex(26));
        }

        [TestMethod()]
        public void ToHexTest_4()
        {
            Assert.IsTrue("10004" == t404.ToHex(65540));
        }

        #endregion

        #region T409 tests : 求最长回文串长度

        [TestMethod()]
        public void LongestPalindromeTest_1()
        {
            Assert.IsTrue(2 == t404.LongestPalindrome("aa"));
        }

        [TestMethod()]
        public void LongestPalindromeTest_2()
        {
            Assert.IsTrue(7 == t404.LongestPalindrome("abccccdd"));
        }

        [TestMethod()]
        public void LongestPalindromeTest_3()
        {
            Assert.IsTrue(1 == t404.LongestPalindrome("AaBb"));
        }

        [TestMethod()]
        public void LongestPalindromeTest_4()
        {
            string str = "civilwartestingwhetherthatnaptionoranynartionsoconceivedandsod " +
                "edicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometod" +
                "edicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirliv" +
                "esthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButin" +
                "alargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebrav" +
                "elmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddo" +
                "rdetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverfor" +
                "getwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedwork" +
                "whichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicate" +
                "dtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevoti" +
                "ontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresol" +
                "vethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirtho" +
                "ffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth";
            Assert.IsTrue(983 == t404.LongestPalindrome(str));
        }




        #endregion

        #region T414 tests : 求数组中第三大的数s

        [TestMethod()]
        public void ThirdMaxTest_1()
        {
            Assert.IsTrue(1 == t404.ThirdMax(new int[] { 3, 2, 1 }));
        }

        [TestMethod()]
        public void ThirdMaxTest_2()
        {
            Assert.IsTrue(1 == t404.ThirdMax(new int[] { 2, 2, 3, 1 }));
        }

        [TestMethod()]
        public void ThirdMaxTest_3()
        {
            Assert.IsTrue(4 == t404.ThirdMax(new int[] { 3, 7, 6, 2, 4, 1 }));
        }

        [TestMethod()]
        public void ThirdMaxTest_4()
        {
            Assert.IsTrue(3 == t404.ThirdMax(new int[] { 3 }));
        }

        [TestMethod()]
        public void ThirdMaxTest_5()
        {
            Assert.IsTrue(-2147483648 == t404.ThirdMax(new int[] { 1, 2, -2147483648, -2147483648 }));
        }

        #endregion

        #region T415 tests : 代表数字的字符串相加

        [TestMethod()]
        public void AddStringsTest_1()
        {
            Assert.IsTrue("3" == t404.AddStrings("1", "2"));
        }

        [TestMethod()]
        public void AddStringsTest_2()
        {
            Assert.IsTrue("2" == t404.AddStrings("0", "2"));
        }

        [TestMethod()]
        public void AddStringsTest_3()
        {
            Assert.IsTrue("10011" == t404.AddStrings("9999", "12"));
        }

        [TestMethod()]
        public void AddStringsTest_4()
        {
            Assert.IsTrue("456" == t404.AddStrings("456", ""));
        }

        [TestMethod()]
        public void AddStringsTest_5()
        {
            Assert.IsTrue("" == t404.AddStrings("", ""));
        }

        #endregion

        #region T434 tests : 字符串中的单词数

        [TestMethod()]
        public void CountSegmentsTest_1()
        {
            Assert.IsTrue(6 == t404.CountSegments(",        , , , a, eaefa"));
        }

        #endregion

        #region T427 tests : 建立四叉树

        [TestMethod()]
        public void ConstructTest_1()
        {
            int[][] grid = {
                new int[] { 1,1,1,1,0,0,0,0 },
                new int[] { 1,1,1,1,0,0,0,0 },
                new int[] { 1,1,1,1,1,1,1,1 },
                new int[] { 1,1,1,1,1,1,1,1 },
                new int[] { 1,1,1,1,0,0,0,0 },
                new int[] { 1,1,1,1,0,0,0,0 },
                new int[] { 1,1,1,1,0,0,0,0 },
                new int[] { 1,1,1,1,0,0,0,0 }
            };
            QuadTreeNode tree = t404.Construct(grid);
            Assert.IsTrue(tree != null);
        }

        [TestMethod()]
        public void ConstructTest_2()
        {
            int[][] grid = {
                new int[] { 1 }
            };
            QuadTreeNode tree = t404.Construct(grid);
            Assert.IsTrue(tree != null);
        }

        [TestMethod()]
        public void ConstructTest_3()
        {
            int[][] grid = {
                new int[] { 1,1,0,0,0,0,0,0 },
                new int[] { 1,1,0,0,0,0,0,0},
                new int[] { 1,1,0,0,0,0,1,1},
                new int[] { 1,1,0,0,0,0,1,1 },
                new int[] { 0,0,0,0,0,0,1,1 },
                new int[] { 0,0,0,0,0,0,1,1 },
                new int[] { 1,1,1,1,1,1,0,0 },
                new int[] { 1,1,1,1,1,1,0,0 },
            };
            QuadTreeNode tree = t404.Construct(grid);
            Assert.IsTrue(tree != null);
        }

        #endregion

    }
}