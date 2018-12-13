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
    }
}