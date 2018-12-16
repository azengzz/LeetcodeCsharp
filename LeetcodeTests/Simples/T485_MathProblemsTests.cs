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
    public class T485_MathProblemsTests
    {
        T485_MathProblems t485 = new T485_MathProblems();

        #region T485 tests : 求二进制数组中最大连续1的个数

        [TestMethod()]
        public void FindMaxConsecutiveOnesTest_1()
        {
            Assert.IsTrue(5 == t485.FindMaxConsecutiveOnes(new int[] { 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1 }));
        }

        #endregion

        #region T492 tests : 构造矩形

        [TestMethod()]
        public void ConstructRectangleTest_1()
        {
            int[] expect = { 11, 2 };
            Assert.IsTrue(true == CompareHelper.CompareArrays(expect, t485.ConstructRectangle(22)));
        }

        #endregion

        #region T496 tests : 寻找下一个更大的元素

        [TestMethod()]
        public void NextGreaterElementTest_1()
        {
            int[] expect = { -1, 3, -1 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect,
                t485.NextGreaterElement(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 })));
        }

        [TestMethod()]
        public void NextGreaterElementTest_2()
        {
            int[] expect = { -1, 5, -1, 5 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect,
                t485.NextGreaterElement(new int[] { 5, 3, 6, 4 }, new int[] { 7, 8, 9, 2, 10, 6, 1, 4, 3, 5 })));
        }

        #endregion

        #region T500 tests : 判断单词是否在键盘上的同一行

        [TestMethod()]
        public void FindWordsTest_1()
        {
            string[] words = { "Hello", "Alaska", "Dad", "Peace" };
            string[] expect = { "Alaska", "Dad" };

            Assert.IsTrue(CompareHelper.CompareArrays<string>(expect, t485.FindWords(words)));
        }

        #endregion

        #region T501 tests : 二叉搜索树中的众数

        [TestMethod()]
        public void FindModeTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, null, 2, 2 });
            int[] expect = { 2 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t485.FindMode(tree)));
        }

        [TestMethod()]
        public void FindModeTest_2()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 3, 2, 3, 1, 2, null, 4 });
            int[] expect = { 2, 3 };
            Assert.IsTrue(CompareHelper.CompareArrays(expect, t485.FindMode(tree)));
        }

        #endregion

        #region T504 tests : 七进制数

        [TestMethod()]
        public void ConvertToBase7Test_1()
        {
            Assert.IsTrue("202" == t485.ConvertToBase7(100));
        }

        [TestMethod()]
        public void ConvertToBase7Test_2()
        {
            Assert.IsTrue("-202" == t485.ConvertToBase7(-100));
        }

        [TestMethod()]
        public void ConvertToBase7Test_3()
        {
            Assert.IsTrue("-12506414" == t485.ConvertToBase7(-1145141));
        }

        #endregion

        #region T506 tests : 相对名次

        [TestMethod()]
        public void FindRelativeRanksTest_1()
        {
            int[] nums = { 5, 4, 3, 2, 1 };
            string[] expect = { "Gold Medal", "Silver Medal", "Bronze Medal", "4", "5" };
            Assert.IsTrue(CompareHelper.CompareArrays<string>(expect, t485.FindRelativeRanks(nums)));
        }

        #endregion

        #region T507 tests : 完美数

        [TestMethod()]
        public void CheckPerfectNumberTest_1()
        {
            Assert.IsTrue(true == t485.CheckPerfectNumber(28));
        }

        [TestMethod()]
        public void CheckPerfectNumberTest_2()
        {
            Assert.IsTrue(false == t485.CheckPerfectNumber(27));
        }

        [TestMethod()]
        public void CheckPerfectNumberTest_3()
        {
            Assert.IsTrue(false == t485.CheckPerfectNumber(1));
        }

        #endregion

        #region T520 tests : 检测大写字母

        [TestMethod()]
        public void DetectCapitalUseTest_1()
        {
            Assert.IsTrue(true == t485.DetectCapitalUse("USA"));
        }

        [TestMethod()]
        public void DetectCapitalUseTest_2()
        {
            Assert.IsTrue(true == t485.DetectCapitalUse("leetcode"));
        }

        [TestMethod()]
        public void DetectCapitalUseTest_3()
        {
            Assert.IsTrue(true == t485.DetectCapitalUse("Google"));
        }

        [TestMethod()]
        public void DetectCapitalUseTest_4()
        {
            Assert.IsTrue(false == t485.DetectCapitalUse("FlaG"));
        }

        #endregion

        #region T530 tests : 二叉搜索树的最小绝对值差

        [TestMethod()]
        public void GetMinimumDifferenceTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, null, 3, 2 });
            Assert.IsTrue(1 == t485.GetMinimumDifference(tree));
        }

        [TestMethod()]
        public void GetMinimumDifferenceTest_2()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 100, 50, 200, 20, 60, 170, 260 });
            Assert.IsTrue(10 == t485.GetMinimumDifference(tree));
        }

        [TestMethod()]
        public void GetMinimumDifferenceTest_3()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, null, 5, 3 });
            Assert.IsTrue(2 == t485.GetMinimumDifference(tree));
        }

        #endregion

        #region T532 tests : 寻找数组中的K-diff数对

        [TestMethod()]
        public void FindPairsTest_1()
        {
            int[] nums = { 3, 1, 4, 1, 5 };
            int k = 2;
            Assert.IsTrue(2 == t485.FindPairs(nums, k));
        }

        [TestMethod()]
        public void FindPairsTest_2()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            int k = 1;
            Assert.IsTrue(4 == t485.FindPairs(nums, k));
        }

        [TestMethod()]
        public void FindPairsTest_3()
        {
            int[] nums = { 1, 3, 1, 5, 4 };
            int k = 0;
            Assert.IsTrue(1 == t485.FindPairs(nums, k));
        }

        [TestMethod()]
        public void FindPairsTest_4()
        {
            int[] nums = { 1, 1, 1, 2, 1 };
            int k = 1;
            Assert.IsTrue(1 == t485.FindPairs(nums, k));
        }

        #endregion

        #region T538 tests : 把二叉搜索树转换为累加树

        [TestMethod()]
        public void ConvertBSTTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 5, 2, 13 });
            TreeNode newTree = t485.ConvertBST(tree);
            object[] res = TreeHelper.BreadthFirstTraverse(newTree);
            object[] expect = new object[] { 18, 20, 13 };
            Assert.IsTrue(true == CompareHelper.CompareArrays<object>(expect, res));
        }

        [TestMethod()]
        public void ConvertBSTTest_2()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 5, 3, 8, 2, null, 6, 9 });
            TreeNode newTree = t485.ConvertBST(tree);
            object[] res = TreeHelper.BreadthFirstTraverse(newTree);
            object[] expect = new object[] { 28, 31, 17, 33, null, 23, 9 };
            Assert.IsTrue(true == CompareHelper.CompareArrays<object>(expect, res));
        }

        #endregion

        #region T541 tests : 反转字符串，每隔k个字符翻转

        [TestMethod()]
        public void ReverseStrTest_1()
        {
            string s = "abcdefg";
            int k = 2;
            string expect = "bacdfeg";
            Assert.IsTrue(expect == t485.ReverseStr(s, k));
        }

        [TestMethod()]
        public void ReverseStrTest_2()
        {
            string s = "abcdefghijklmnopqrstuvw";
            int k = 3;
            string expect = "cbadefihgjklonmpqrutsvw";
            Assert.IsTrue(expect == t485.ReverseStr(s, k));
        }

        [TestMethod()]
        public void ReverseStrTest_3()
        {
            string s = "abcd";
            int k = 4;
            string expect = "dcba";
            Assert.IsTrue(expect == t485.ReverseStr(s, k));
        }

        #endregion

        #region T543 tests : 二叉树的直径

        [TestMethod()]
        public void DiameterOfBinaryTreeTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(3 == t485.DiameterOfBinaryTree(tree));
        }

        [TestMethod()]
        public void DiameterOfBinaryTreeTest_2()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, 2, 3, 4, 5, null, null, null, null, 6, null });
            Assert.IsTrue(4 == t485.DiameterOfBinaryTree(tree));
        }

        [TestMethod()]
        public void DiameterOfBinaryTreeTest_3()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 1, null, 2, 3, 4, null, null, null, 5 });
            Assert.IsTrue(3 == t485.DiameterOfBinaryTree(tree));
        }

        #endregion

        #region T551 tests : 学生出勤记录

        [TestMethod()]
        public void CheckRecordTest_1()
        {
            Assert.IsTrue(true == t485.CheckRecord("PPALLP"));
        }

        [TestMethod()]
        public void CheckRecordTest_2()
        {
            Assert.IsTrue(false == t485.CheckRecord("PPALLL"));
        }

        [TestMethod()]
        public void CheckRecordTest_3()
        {
            Assert.IsTrue(false == t485.CheckRecord("AAAA"));
        }

        #endregion

        #region T557 tests : 反转字符串中的单词

        [TestMethod()]
        public void ReverseWordsTest_1()
        {
            string s = "Let's take LeetCode contest";
            string expect = "s'teL ekat edoCteeL tsetnoc";
            Assert.IsTrue(expect == t485.ReverseWords(s));
        }

        [TestMethod()]
        public void ReverseWordsTest_2()
        {
            string s = "L";
            string expect = "L";
            Assert.IsTrue(expect == t485.ReverseWords(s));
        }

        [TestMethod()]
        public void ReverseWordsTest_3()
        {
            string s = "    ";
            string expect = "";
            Assert.IsTrue(expect == t485.ReverseWords(s));
        }

        [TestMethod()]
        public void ReverseWordsTest_4()
        {
            string s = "we     are    no    1    ";
            string expect = "ew era on 1";
            Assert.IsTrue(expect == t485.ReverseWords(s));
        }

        #endregion

        #region T561 tests : 数组拆分

        [TestMethod()]
        public void ArrayPairSumTest_1()
        {
            int[] nums = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            Assert.IsTrue(45 == t485.ArrayPairSum(nums));
        }

        #endregion
    }
}