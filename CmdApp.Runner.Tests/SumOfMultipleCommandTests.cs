using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CmdApp.Runner.Tests {
    [TestClass]
    public class SumOfMultipleCommandTests {
        [TestMethod]
        [DataRow(5874698)]
        [DataRow(456)]
        public void Should_execute_service(int limit) {
            var service = new SumOfMultipleCommand {
                Limit = limit.ToString()
            };

            var expected = new SumOfMultiple.SumOfMultiple(limit).Execute();

            var (consoleMock, textWriterMock) = MockConsole();
            service.OnExecute(consoleMock.Object);

            textWriterMock.Verify(mock => mock.WriteLine(It.IsAny<string>()));
            textWriterMock.Verify(mock => mock.WriteLine(expected.ToString("#,##0")));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_limit_was_not_entered() {
            var service = new SumOfMultipleCommand {
                Limit = null
            };

            var (consoleMock, _) = MockConsole();
            service.OnExecute(consoleMock.Object);
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

            var (consoleMock, _) = MockConsole();
            service.OnExecute(consoleMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_throw_exception_if_limit_below_0() {
            var service = new SumOfMultipleCommand {
                Limit = "-1"
            };

            var (consoleMock, _) = MockConsole();
            service.OnExecute(consoleMock.Object);
        }

        private static (Mock<IConsole>, Mock<TextWriter>) MockConsole() {
            var consoleMock = new Mock<IConsole>();
            var textWriterMock = new Mock<TextWriter>();
            consoleMock.SetupGet(mock => mock.Out).Returns(textWriterMock.Object);

            return (consoleMock, textWriterMock);
        }
    }
}
