using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        [TestMethod()]
        public void RomanNumberTest()
        {
            ushort a = 0;
            ushort b = 4000;
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(a));
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(b));

            RomanNumber[] romanNumber = new RomanNumber[3999];
            for(int i = 0; i < 3999; i++)
                romanNumber[i] = new RomanNumber((ushort)((i+1)));
            for (int i = 0; i < 3999; i++)
                Assert.IsNotNull(romanNumber[i].ToString());
        }

        [TestMethod()]
        public void AddTest()
        {
            RomanNumber[] romanNumber = new RomanNumber[3];
            string expected = "XXX";
            string tested = "";
            romanNumber[0] = new RomanNumber(10);
            romanNumber[1] = new RomanNumber(20);
            romanNumber[2] = romanNumber[1] + romanNumber[0];
            tested = romanNumber[2].ToString();

            Assert.AreEqual(expected, tested);

            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = romanNumber[1] + null);
            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = null + romanNumber[1]);
        }

        [TestMethod()]
        public void SubTest()
        {
            RomanNumber[] romanNumber = new RomanNumber[3];
            string expected = "X";
            string tested = "";
            romanNumber[0] = new RomanNumber(10);
            romanNumber[1] = new RomanNumber(20);
            romanNumber[2] = romanNumber[1] - romanNumber[0];
            tested = romanNumber[2].ToString();

            Assert.AreEqual(expected, tested);

            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = romanNumber[1] - null);
            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = null - romanNumber[1]);

            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = romanNumber[1] - romanNumber[1]);
        }

        [TestMethod()]
        public void MulTest()
        {
            RomanNumber[] romanNumber = new RomanNumber[3];
            string expected = "CC";
            string tested = "";
            romanNumber[0] = new RomanNumber(10);
            romanNumber[1] = new RomanNumber(20);
            romanNumber[2] = romanNumber[1] * romanNumber[0];
            tested = romanNumber[2].ToString();

            Assert.AreEqual(expected, tested);

            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = romanNumber[1] * null);
            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = null * romanNumber[1]);
        }

        [TestMethod()]
        public void DivTest()
        {
            RomanNumber[] romanNumber = new RomanNumber[3];
            string expected = "II";
            string tested = "";
            romanNumber[0] = new RomanNumber(10);
            romanNumber[1] = new RomanNumber(20);
            romanNumber[2] = romanNumber[1] / romanNumber[0];
            tested = romanNumber[2].ToString();

            Assert.AreEqual(expected, tested);

            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = romanNumber[1] / null);
            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = null / romanNumber[1]);

            Assert.ThrowsException<RomanNumberException>(() => romanNumber[2] = romanNumber[0] / romanNumber[1]);
        }

        [TestMethod()]
        public void CloneTest()
        {
            RomanNumber X = new RomanNumber(10);
            RomanNumber X2 = (RomanNumber)X.Clone();
            string expected = X.ToString();
            string tested = X2.ToString();

            Assert.AreEqual(expected, tested);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            RomanNumber romanNumber = new RomanNumber(10);
            string expected = "X";
            string tested = "";
            tested = romanNumber.ToString();

            Assert.AreEqual(expected, tested);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            RomanNumber[] romanNumber = new RomanNumber[2];
            int[] tested = new int[3];
            int[] expected = new int[3];
            romanNumber[0] = new RomanNumber(10);
            romanNumber[1] = new RomanNumber(20);

            tested[0] = romanNumber[0].CompareTo(romanNumber[1]);
            expected[0] = -10;
            tested[1] = romanNumber[1].CompareTo(romanNumber[0]);
            expected[1] = 10;
            tested[2] = romanNumber[0].CompareTo(romanNumber[0]);
            expected[2] = 0;

            Assert.AreEqual(expected[0], tested[0]);
            Assert.AreEqual(expected[1], tested[1]);
            Assert.AreEqual(expected[2], tested[2]);

        }
    }
}