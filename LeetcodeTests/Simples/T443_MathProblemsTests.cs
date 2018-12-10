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
    }
}