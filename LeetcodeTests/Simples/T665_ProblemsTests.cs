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
    public class T665_ProblemsTests
    {
        T665_Problems t665 = new T665_Problems();

        #region T665 tests : 非递减数列

        [TestMethod()]
        public void CheckPossibilityTest_1()
        {
            int[] nums = { 4, 2, 3 };
            Assert.IsTrue(true == t665.CheckPossibility(nums));
        }

        [TestMethod()]
        public void CheckPossibilityTest_2()
        {
            int[] nums = { 4, 2, 1 };
            Assert.IsTrue(false == t665.CheckPossibility(nums));
        }

        [TestMethod()]
        public void CheckPossibilityTest_3()
        {
            int[] nums = { 3, 4, 2, 3 };
            Assert.IsTrue(false == t665.CheckPossibility(nums));
        }

        [TestMethod()]
        public void CheckPossibilityTest_4()
        {
            int[] nums = { 1, 5, 4, 6, 7, 10, 8, 9 };
            Assert.IsTrue(false == t665.CheckPossibility(nums));
        }

        #endregion

        #region T671 tests : 二叉树中第二小的节点

        [TestMethod()]
        public void FindSecondMinimumValueTest_1()
        {
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(new object[] { 10, 10, 11, null, null, 11, 11 });
            Assert.IsTrue(11 == t665.FindSecondMinimumValue(tree));
        }

        #endregion

        #region T674 tests : 最长连续递增序列

        [TestMethod()]
        public void FindLengthOfLCISTest_1()
        {
            int[] nums = { 1, 3, 5, 4, 7 };
            Assert.IsTrue(3 == t665.FindLengthOfLCIS(nums));
        }

        [TestMethod()]
        public void FindLengthOfLCISTest_2()
        {
            int[] nums = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            Assert.IsTrue(1 == t665.FindLengthOfLCIS(nums));
        }

        [TestMethod()]
        public void FindLengthOfLCISTest_3()
        {
            int[] nums = { 2 };
            Assert.IsTrue(1 == t665.FindLengthOfLCIS(nums));
        }

        [TestMethod()]
        public void FindLengthOfLCISTest_4()
        {
            int[] nums = { 1, 2, 3, 2, 2, 2, 2, 2, 2, 2, 3, 4, 5 };
            Assert.IsTrue(4 == t665.FindLengthOfLCIS(nums));
        }

        #endregion

        #region T680 tests : 验证回文字符串

        [TestMethod()]
        public void ValidPalindromeTest_1()
        {
            string s = "aba";
            Assert.IsTrue(true == t665.ValidPalindrome(s));
        }

        [TestMethod()]
        public void ValidPalindromeTest_2()
        {
            string s = "abcbma";
            Assert.IsTrue(true == t665.ValidPalindrome(s));
        }

        [TestMethod()]
        public void ValidPalindromeTest_3()
        {
            string s = "abcd";
            Assert.IsTrue(false == t665.ValidPalindrome(s));
        }

        #endregion

        #region T682 tests : 棒球比赛计分
        //不用考虑不符合实际记分情况的输入。比如全是D或全是+
        [TestMethod()]
        public void CalPointsTest_1()
        {
            Assert.IsTrue(30 == t665.CalPoints(new string[] { "5", "2", "C", "D", "+" }));
        }

        [TestMethod()]
        public void CalPointsTest_2()
        {
            Assert.IsTrue(27 == t665.CalPoints(new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" }));
        }

        #endregion

        #region T686 tests : 重复叠加字符串匹配

        [TestMethod()]
        public void RepeatedStringMatchTest_1()
        {
            string A = "abcd";
            string B = "cdabcdab";
            Assert.IsTrue(3 == t665.RepeatedStringMatch(A, B));
        }

        [TestMethod()]
        public void RepeatedStringMatchTest_2()
        {
            string A = "abcd";
            string B = "da";
            Assert.IsTrue(2 == t665.RepeatedStringMatch(A, B));
        }

        [TestMethod()]
        public void RepeatedStringMatchTest_3()
        {
            string A = "abcd";
            string B = "dm";
            Assert.IsTrue(-1 == t665.RepeatedStringMatch(A, B));
        }

        [TestMethod()]
        public void RepeatedStringMatchTest_4()
        {
            string A = "abcd";
            string B = "";
            Assert.IsTrue(0 == t665.RepeatedStringMatch(A, B));
        }

        #endregion

        #region T690 tests : 员工的重要性

        [TestMethod()]
        public void GetImportanceTest_1()
        {
            List<T665_Problems.Employee> employees = new List<T665_Problems.Employee>
            {
                new T665_Problems.Employee(1, 5, new List<int> {2,3 }),
                new T665_Problems.Employee(2, 3, new List<int> {4,5 }),
                new T665_Problems.Employee(3, 3, new List<int> {6,7 }),
                new T665_Problems.Employee(4, 1, new List<int> { }),
                new T665_Problems.Employee(5, 1, new List<int> { }),
                new T665_Problems.Employee(6, 1, new List<int> { }),
                new T665_Problems.Employee(7, 1, new List<int> { }),
            };

            Assert.IsTrue(15 == t665.GetImportance(employees, 1));
        }

        #endregion

        #region T693 tests : 交替二进制数

        [TestMethod()]
        public void HasAlternatingBitsTest_1()
        {
            Assert.IsTrue(true == t665.HasAlternatingBits(5));
        }

        [TestMethod()]
        public void HasAlternatingBitsTest_2()
        {
            Assert.IsTrue(false == t665.HasAlternatingBits(7));
        }

        #endregion

        #region T696 tests : 计数二进制子串

        [TestMethod()]
        public void CountBinarySubstringsTest_1()
        {
            Assert.IsTrue(6 == t665.CountBinarySubstrings("00110011"));
        }

        [TestMethod()]
        public void CountBinarySubstringsTest_2()
        {
            Assert.IsTrue(4 == t665.CountBinarySubstrings("10101"));
        }

        [TestMethod()]
        public void CountBinarySubstringsTest_3()
        {
            Assert.IsTrue(4 == t665.CountBinarySubstrings("1010001"));
        }

        #endregion

        #region T697 tests : 数组的度

        [TestMethod()]
        public void FindShortestSubArrayTest_1()
        {
            int[] nums = { 1, 2, 2, 3, 1 };
            Assert.IsTrue(2 == t665.FindShortestSubArray(nums));
        }

        [TestMethod()]
        public void FindShortestSubArrayTest_2()
        {
            int[] nums = { 1, 2, 2, 3, 1, 4, 2 };
            Assert.IsTrue(6 == t665.FindShortestSubArray(nums));
        }

        [TestMethod()]
        public void FindShortestSubArrayTest_3()
        {
            int[] nums = { 5 };
            Assert.IsTrue(1 == t665.FindShortestSubArray(nums));
        }

        #endregion

        #region T703 tests : 寻找第K大的数

        [TestMethod()]
        public void FindKthLargestNum_1()
        {
            T665_Problems.KthLargest KL = new T665_Problems.KthLargest(3, new int[] { 4, 5, 8, 2 });
            Assert.IsTrue(4 == KL.Add(3));
            Assert.IsTrue(5 == KL.Add(5));
            Assert.IsTrue(5 == KL.Add(10));
            Assert.IsTrue(8 == KL.Add(9));
            Assert.IsTrue(8 == KL.Add(4));
        }

        [TestMethod()]
        public void FindKthLargestNum_2()
        {
            T665_Problems.KthLargest KL = new T665_Problems.KthLargest(1, new int[] { });
            Assert.IsTrue(-3 == KL.Add(-3));
            Assert.IsTrue(-2 == KL.Add(-2));
            Assert.IsTrue(-2 == KL.Add(-4));
            Assert.IsTrue(0 == KL.Add(0));
            Assert.IsTrue(4 == KL.Add(4));
        }

        [TestMethod()]
        public void FindKthLargestNum_3()
        {
            T665_Problems.KthLargest KL = new T665_Problems.KthLargest(2, new int[] { 0 });
            Assert.IsTrue(-1 == KL.Add(-1));
            Assert.IsTrue(0 == KL.Add(1));
            Assert.IsTrue(0 == KL.Add(-2));
            Assert.IsTrue(0 == KL.Add(-4));
            Assert.IsTrue(1 == KL.Add(3));
        }

        #endregion

        #region T705 tests : 设计哈希集合

        [TestMethod]
        public void MyHashSetTest_1()
        {
            T665_Problems.MyHashSet hs = new T665_Problems.MyHashSet();
            hs.Add(1);
            hs.Add(2);
            Assert.IsTrue(true == hs.Contains(1));
            Assert.IsTrue(false == hs.Contains(3));
            hs.Add(2);
            Assert.IsTrue(true == hs.Contains(2));
            hs.Remove(2);
            Assert.IsTrue(false == hs.Contains(2));
        }

        #endregion

        #region T706 tests : 设计哈希映射

        [TestMethod]
        public void MyHashMapTest_1()
        {
            T665_Problems.MyHashMap hm = new T665_Problems.MyHashMap();
            hm.Put(1, 1);
            hm.Put(2, 2);
            Assert.IsTrue(1 == hm.Get(1));
            Assert.IsTrue(-1 == hm.Get(3));
            hm.Put(2, 1);
            Assert.IsTrue(1 == hm.Get(2));
            hm.Remove(2);
        }

        #endregion

        #region T707 tests : 设计链表

        [TestMethod]
        public void MyLinkedListTest_1()
        {
            T665_Problems.MyLinkedList mylist = new T665_Problems.MyLinkedList();
            mylist.AddAtHead(1);
            mylist.AddAtTail(3);
            mylist.AddAtIndex(1, 2);
            Assert.IsTrue(2 == mylist.Get(1));
            mylist.DeleteAtIndex(1);
            Assert.IsTrue(3 == mylist.Get(1));
        }

        #endregion

        #region T717 tests : 1比特与2比特字符串的最后一个字符是否是1比特字符

        [TestMethod()]
        public void IsOneBitCharacterTest()
        {
            int[] bits = { 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0,
                1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1,
                0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0,
                1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1,
                0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0 };
            Assert.IsTrue(true == t665.IsOneBitCharacter(bits));
        }

        #endregion

        #region T720 tests : 词典中最长的单词

        [TestMethod()]
        public void LongestWordTest_1()
        {
            string[] words = new string[] { "w", "wo", "wor", "worl", "world" };
            Assert.IsTrue("world" == t665.LongestWord(words));
        }

        [TestMethod()]
        public void LongestWordTest_2()
        {
            string[] words = new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" };
            Assert.IsTrue("apple" == t665.LongestWord(words));
        }

        [TestMethod()]
        public void LongestWordTest_3()
        {
            string[] words = new string[] { "a", "banana", "app", "appl", "ban", "b", "ba", "banan", "bana", "ap", "apply", "apple" };
            Assert.IsTrue("banana" == t665.LongestWord(words));
        }

        #endregion

        #region T724 tests : 寻找数组的中心索引

        [TestMethod()]
        public void PivotIndexTest_1()
        {
            int[] nums = { 1, 7, 3, 6, 5, 6 };
            Assert.IsTrue(3 == t665.PivotIndex(nums));
        }

        [TestMethod()]
        public void PivotIndexTest_2()
        {
            int[] nums = { 1, 2, 3 };
            Assert.IsTrue(-1 == t665.PivotIndex(nums));
        }

        [TestMethod()]
        public void PivotIndexTest_3()
        {
            int[] nums = { 2, 2 };
            Assert.IsTrue(-1 == t665.PivotIndex(nums));
        }

        #endregion

        #region T728 tests : 自除数

        [TestMethod()]
        public void SelfDividingNumbersTest_1()
        {
            List<int> expect = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22 };
            Assert.IsTrue(CompareHelper.CompareList<int>(expect, t665.SelfDividingNumbers(1, 22)));
        }

        #endregion
    }
}