using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests {
    [TestClass]
    public sealed class SumOfMultipleTests {
        [TestMethod]
        [DataRow(-1)]
        [DataRow(-789)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_throw_exception_when_limit_is_below_0(int limit) {
            var service = new SumOfMultiple();
            var dummy = service.Execute(limit);
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
        public void Shoud_return_sum_of_multiples_of_3_or_5(ulong limit, string expectedString) {
            var expected = BigInteger.Parse(expectedString);

            var service = new SumOfMultiple();
            var actual = service.Execute(limit);

            Assert.AreEqual(expected, actual);
        }
    }
}