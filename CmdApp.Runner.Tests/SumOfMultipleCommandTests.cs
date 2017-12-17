using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CmdApp.Runner.Tests {
    [TestClass]
    public sealed class SumOfMultipleCommandTests {
        private ConsoleMock _consoleMock;

        [TestInitialize]
        public void SetUp() {
            _consoleMock = new ConsoleMock();
        }

        [TestMethod]
        public void Should_specify_name() {
            const string expected = "sumOfMultiple";

            const string actual = SumOfMultipleCommand.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(5874698)]
        [DataRow(456)]
        public void Should_execute_service(int limit) {
            var service = new SumOfMultipleCommand {
                LimiteAsString = limit.ToString()
            };

            var expected = new Domain.SumOfMultiple().Execute(limit);

            service.OnExecute(_consoleMock.Object);

            _consoleMock.VerifyWriteLine(expected.ToString("#,##0"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_limit_was_not_entered() {
            var service = new SumOfMultipleCommand {
                LimiteAsString = null
            };

            service.OnExecute(_consoleMock.Object);
        }

        [TestMethod]
        [DataRow("AGC")]
        [DataRow("*")]
        [DataRow("true")]
        [DataRow("12/12/2015")]
        [DataRow("15 85")]
        [DataRow("")]
        [ExpectedException(typeof(FormatException))]
        public void Should_throw_exception_if_limit_was_not_valid(string limit) {
            var service = new SumOfMultipleCommand {
                LimiteAsString = limit
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_throw_exception_if_limit_below_0() {
            var service = new SumOfMultipleCommand {
                LimiteAsString = "-1"
            };

            service.OnExecute(_consoleMock.Object);
        }

        [TestMethod]
        public void Should_return_success() {
            var service = new SumOfMultipleCommand {
                LimiteAsString = "10"
            };
            var actual = service.OnExecute(_consoleMock.Object);

            Assert.AreEqual(1, actual);
        }
    }
}
