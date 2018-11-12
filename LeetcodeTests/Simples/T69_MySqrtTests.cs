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
    public class T69_MySqrtTests
    {
        T69_MySqrt t69 = new T69_MySqrt();

        [TestMethod()]
        public void MySqrtTest_input_4()
        {
            int input = 4;
            int expect = 2;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }

        [TestMethod()]
        public void MySqrtTest_input_9()
        {
            int input = 9;
            int expect = 3;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }

        [TestMethod()]
        public void MySqrtTest_input_8()
        {
            int input = 8;
            int expect = 2;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }

        [TestMethod()]
        public void MySqrtTest_input_17()
        {
            int input = 17;
            int expect = 4;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }

        [TestMethod()]
        public void MySqrtTest_input_0()
        {
            int input = 0;
            int expect = 0;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }

        [TestMethod()]
        public void MySqrtTest_input_1()
        {
            int input = 1;
            int expect =1;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }

        [TestMethod()]
        public void MySqrtTest_input_65536()
        {
            int input = 65536;
            int expect = 256;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }
       
        [TestMethod()]
        public void MySqrtTest_input_very_large()
        {
            int input = 2147395599;
            int expect = 46339;
            int result = t69.MySqrt(input);
            Assert.IsTrue(result == expect);
        }
    }
}