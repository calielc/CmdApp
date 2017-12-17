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
        [DataRow(5874698)]
        [DataRow(456)]
        public void Should_execute_service(int limit) {
            var service = new SumOfMultipleCommand {
                Limit = limit.ToString()
            };

            var expected = new SumOfMultiple.SumOfMultiple().Execute(limit);

            service.OnExecute(_consoleMock.Object);

            _consoleMock.VerifyWriteLine(expected.ToString("#,##0"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_limit_was_not_entered() {
            var service = new SumOfMultipleCommand {
                Limit = null
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
                Limit = limit
            };

            service.OnExecute(_consoleMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_throw_exception_if_limit_below_0() {
            var service = new SumOfMultipleCommand {
                Limit = "-1"
            };

            service.OnExecute(_consoleMock.Object);
        }
    }
}
