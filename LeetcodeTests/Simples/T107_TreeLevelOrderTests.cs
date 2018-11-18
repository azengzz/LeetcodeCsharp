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
    public class T107_TreeLevelOrderTests
    {
        T107_TreeLevelOrder t107 = new T107_TreeLevelOrder();

        //private bool CompareListList(IList<IList<int>> expect, IList<IList<int>> result)
        //{
        //    if (expect.Count != result.Count) return false;

        //    for (int i = 0; i < result.Count; i++)
        //    {
        //        if (expect[i].Count != result[i].Count) return false;
        //        for (int j = 0; j < result[i].Count; j++)
        //        {
        //            if (result[i][j] != expect[i][j]) return false;
        //        }
        //    }

        //    return true;
        //}

        [TestMethod()]
        public void LevelOrderBottomTest_1()
        {
            object[] nodes = { 3, 9, 20, null, null, 15, 7 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            IList<IList<int>> result = t107.LevelOrderBottom(tree);
            IList<IList<int>> expect = new List<IList<int>>(){ new List<int>{ 15, 7 }, new List<int>{ 9, 20 }, new List<int>{ 3 } };

            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }

        [TestMethod()]
        public void LevelOrderBottomTest_2()
        {
            object[] nodes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, null, null, null, null, null, null, null, null, null, null, 11 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            IList<IList<int>> result = t107.LevelOrderBottom(tree);
            IList<IList<int>> expect = new List<IList<int>>() { new List<int> { 11 }, new List<int> { 8,9,10 }, new List<int> { 4,5,6,7 }, new List<int> { 2,3}, new List<int> { 1 } };

            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }

        [TestMethod()]
        public void LevelOrderBottomTest_3()
        {
            object[] nodes = { 1, 2, null, null, 3, 4, null, null, 5 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            IList<IList<int>> result = t107.LevelOrderBottom(tree);
            IList<IList<int>> expect = new List<IList<int>>() { new List<int> { 5 }, new List<int> { 4 }, new List<int> { 3 }, new List<int> { 2 }, new List<int> { 1 } };

            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }

        [TestMethod()]
        public void LevelOrderBottomTest_4()
        {
            object[] nodes = { 1 };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            IList<IList<int>> result = t107.LevelOrderBottom(tree);
            IList<IList<int>> expect = new List<IList<int>>() { new List<int> { 1 } };

            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }

        [TestMethod()]
        public void LevelOrderBottomTest_5()
        {
            object[] nodes = {  };
            TreeNode tree = TreeHelper.CreateBinaryTreeByArray(nodes);
            IList<IList<int>> result = t107.LevelOrderBottom(tree);
            IList<IList<int>> expect = new List<IList<int>>() ;

            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }
    }
}