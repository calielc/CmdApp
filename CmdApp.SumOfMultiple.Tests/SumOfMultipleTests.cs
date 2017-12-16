using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CmdApp.SumOfMultiple.Tests {
    [TestClass]
    public class SumOfMultipleTests {
        [TestMethod]
        [DataRow(-1)]
        [DataRow(-789)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_throw_exception_when_limit_is_below_0(int limit) {
            var unused = new SumOfMultiple(limit);
        }

        [TestMethod]
        [DataRow(0ul, "0")]
        [DataRow(1ul, "0")]
        [DataRow(2ul, "0")]
        [DataRow(3ul, "0")]
        [DataRow(4ul, "3")]
        [DataRow(5ul, "3")]
        [DataRow(6ul, "8")]
        [DataRow(10ul, "23")]
        [DataRow(16ul, "60")]
        [DataRow(10_000_000ul, "23333331666668")]
        [DataRow(10_000_000_000ul, "23333333331666666668")]
        [DataRow(1_000_000_000_000_000ul, "233333333333333166666666666668")]
        public void Shoud_return_sum_of_multiples_of_3_or_5(ulong limit, string expected) {
            var bigExpected = BigInteger.Parse(expected);

            var service = new SumOfMultiple(limit);
            var actual = service.Execute();

            Assert.AreEqual(bigExpected, actual);
        }
    }
}