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
    public class T118_PascalTraingleTests
    {
        T118_PascalTraingle t108 = new T118_PascalTraingle();

        [TestMethod()]
        public void GenerateTest_1()
        {
            IList<IList<int>> expect = new List<IList<int>>() {
                new List<int>() { 1 },
                new List<int>() { 1,1 },
                new List<int>() { 1,2,1 },
                new List<int>() { 1,3,3,1 },
                new List<int>() { 1,4,6,4,1 },
            };
            IList<IList<int>> result = t108.Generate(5);
            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }

        [TestMethod()]
        public void GenerateTest_2()
        {
            IList<IList<int>> expect = new List<IList<int>>() {
                new List<int>() { 1 },
            };
            IList<IList<int>> result = t108.Generate(1);
            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }

        [TestMethod()]
        public void GenerateTest_3()
        {
            IList<IList<int>> expect = new List<IList<int>>();
            IList<IList<int>> result = t108.Generate(0);
            Assert.IsTrue(CompareHelper.CompareListList(expect, result));
        }

        //-----------------------------------------------

        [TestMethod()]
        public void GetRowTest_1()
        {
            IList<int> expect = new List<int>() { 1,4,6,4,1 };
            IList<int> result = t108.GetRow(4);
            Assert.IsTrue(CompareHelper.CompareList<int>(result, expect));
        }
    }
}