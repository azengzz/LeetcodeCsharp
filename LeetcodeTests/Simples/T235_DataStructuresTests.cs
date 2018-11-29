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
    public class T235_DataStructuresTests
    {
        T235_DataStructures t235 = new T235_DataStructures();

        #region T235 tests : 二叉搜索树的最近公共祖先

        [TestMethod()]
        public void LowestCommonAncestorTest_1()
        {
            object[] nodes = { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            TreeNode p = new TreeNode(3);
            TreeNode q = new TreeNode(5);
            TreeNode expect = new TreeNode(4);

            Assert.IsTrue(expect.val == t235.LowestCommonAncestor(tree, p, q).val);
        }

        [TestMethod()]
        public void LowestCommonAncestorTest_2()
        {
            object[] nodes = { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            TreeNode p = new TreeNode(3);
            TreeNode q = new TreeNode(7);
            TreeNode expect = new TreeNode(6);

            Assert.IsTrue(expect.val == t235.LowestCommonAncestor(tree, p, q).val);
        }

        [TestMethod()]
        public void LowestCommonAncestorTest_3()
        {
            object[] nodes = { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            TreeNode p = new TreeNode(2);
            TreeNode q = new TreeNode(3);
            TreeNode expect = new TreeNode(2);

            Assert.IsTrue(expect.val == t235.LowestCommonAncestor(tree, p, q).val);
        }

        #endregion

        #region T242 tests : 判断是否字母异位词

        [TestMethod()]
        public void IsAnagramTest_1()
        {
            string s = "anagram", t = "nagaram";
            Assert.IsTrue(true == t235.IsAnagram(s, t));
        }


        [TestMethod()]
        public void IsAnagramTest_2()
        {
            string s = "anagram", t = "nagarab";
            Assert.IsTrue(false == t235.IsAnagram(s, t));
        }

        [TestMethod()]
        public void IsAnagramTest_3()
        {
            string s = "aaabb", t = "aabbb";
            Assert.IsTrue(false == t235.IsAnagram(s, t));
        }

        #endregion

        #region T257 tests : 二叉树的所有路径

        [TestMethod()]
        public void BinaryTreePathsTest_1()
        {
            object[] nodes = { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            IList<string> result = t235.BinaryTreePaths(tree);
            Assert.IsTrue(result != null);
        }

        #endregion

        #region T263 tests : 丑数判断

        [TestMethod()]
        public void IsUglyTest_1()
        {
            Assert.IsTrue(true == t235.IsUgly(10));
        }

        [TestMethod()]
        public void IsUglyTest_2()
        {
            Assert.IsTrue(false == t235.IsUgly(456));
        }

        [TestMethod()]
        public void IsUglyTest_3()
        {
            Assert.IsTrue(false == t235.IsUgly(19456416));
        }

        #endregion

        #region T268 tests : 求缺失的数字

        [TestMethod()]
        public void MissingNumberTest_1()
        {
            int[] serial = { 3, 0, 1 };
            Assert.IsTrue(2 == t235.MissingNumber(serial));
        }

        [TestMethod()]
        public void MissingNumberTest_2()
        {
            int[] serial = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            Assert.IsTrue(8 == t235.MissingNumber(serial));
        }

        #endregion

        #region T278 tests : 查找第一个错误的版本号

        //[TestMethod()]
        //public void FirstBadVersionTest_1()
        //{
        //    Assert.IsTrue(4 == t235.FirstBadVersion(5));
        //}

        //[TestMethod()]
        //public void FirstBadVersionTest_2()
        //{
        //    Assert.IsTrue(4 == t235.FirstBadVersion(15));
        //}

        //[TestMethod()]
        //public void FirstBadVersionTest_3()
        //{
        //    Assert.IsTrue(4 == t235.FirstBadVersion(7));
        //}

        //[TestMethod()]
        //public void FirstBadVersionTest_3()
        //{
        //    Assert.IsTrue(1702766719 == t235.FirstBadVersion(2126753390));
        //}

        #endregion

        #region T283 tests : 移动数组中的0到数组尾部

        [TestMethod()]
        public void MoveZeroesTest_1()
        {
            int[] nums = { 1, 0, 2, 4, 0, 3 };
            int[] expect = { 1, 2, 4, 3, 0, 0 };
            t235.MoveZeroes(nums);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        [TestMethod()]
        public void MoveZeroesTest_2()
        {
            int[] nums = { 0, 3, 2, 4, 0, 1, 5, 0, 6 };
            int[] expect = { 3, 2, 4, 1, 5, 6, 0, 0, 0 };
            t235.MoveZeroes(nums);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        [TestMethod()]
        public void MoveZeroesTest_3()
        {
            int[] nums = { 5, 4, 3, 2, 1 };
            int[] expect = { 5, 4, 3, 2, 1 };
            t235.MoveZeroes(nums);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        [TestMethod()]
        public void MoveZeroesTest_4()
        {
            int[] nums = { 3 };
            int[] expect = { 3 };
            t235.MoveZeroes(nums);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        [TestMethod()]
        public void MoveZeroesTest_5()
        {
            int[] nums = { 0, 0, 0, 0, 0, 0 };
            int[] expect = { 0, 0, 0, 0, 0, 0 };
            t235.MoveZeroes(nums);
            Assert.IsTrue(CompareHelper.CompareArrays(nums, expect));
        }

        #endregion

        #region tests : 判断字符串str是否符合模式pattern

        [TestMethod()]
        public void WordPatternTest_1()
        {
            string str = "dog cat cat dog";
            string pattern = "abba";
            Assert.IsTrue(true == t235.WordPattern(pattern, str));
        }

        [TestMethod()]
        public void WordPatternTest_2()
        {
            string str = "dog cat cat fish";
            string pattern = "abba";
            Assert.IsTrue(false == t235.WordPattern(pattern, str));
        }

        [TestMethod()]
        public void WordPatternTest_3()
        {
            string str = "dog cat cat dog";
            string pattern = "aaaa";
            Assert.IsTrue(false == t235.WordPattern(pattern, str));
        }

        [TestMethod()]
        public void WordPatternTest_4()
        {
            string str = "dog dog dog dog";
            string pattern = "abba";
            Assert.IsTrue(false == t235.WordPattern(pattern, str));
        }

        #endregion
    }
}