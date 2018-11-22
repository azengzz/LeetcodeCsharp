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
    public class T190_SomeMathProblemsTests
    {
        T190_SomeMathProblems t190 = new T190_SomeMathProblems();

        #region T190 tests : 颠倒二进制位

        [TestMethod()]
        public void reverseBitsTest_1()
        {
            uint origin = 11;
            uint expect = 3489660928;
            uint result = t190.reverseBits(origin);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void reverseBitsTest_2()
        {
            uint origin = 43261596;
            uint expect = 964176192;
            uint result = t190.reverseBits(origin);
            Assert.IsTrue(expect == result);
        }

        [TestMethod()]
        public void reverseBitsTest_3()
        {
            uint origin = 1;
            uint expect = 2147483648;
            uint result = t190.reverseBits(origin);
            Assert.IsTrue(expect == result);
        }

        #endregion

        #region T191 tests : 位1的个数

        [TestMethod()]
        public void HammingWeightTest_1()
        {
            uint input = 11;
            int expect = 3;
            Assert.IsTrue(expect == t190.HammingWeight(input));
        }

        [TestMethod()]
        public void HammingWeightTest_2()
        {
            uint input = 128;
            int expect = 1;
            Assert.IsTrue(expect == t190.HammingWeight(input));
        }

        #endregion
    }
}