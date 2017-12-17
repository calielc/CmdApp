using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CmdApp.Runner.Tests {
    [TestClass]
    public sealed class SequenceAnalysisCommandTests {
        private ConsoleMock _consoleMock;

        [TestInitialize]
        public void SetUp() {
            _consoleMock = new ConsoleMock();
        }

        [TestMethod]
        [DataRow("This IS a STRING")]
        [DataRow("RbBDwjKtIsWGFgLEyVYMmxqnikTAepUQXPHvhOlJNuScadCrZofz")]
        public void Should_execute_service(string input) {
            var service = new SequenceAnalysisCommand {
                Input = input
            };

            var expected = new SequenceAnalysis.SequenceAnalysis().Execute(input);

            service.OnExecute(_consoleMock.Object);

            _consoleMock.VerifyWriteLine(expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_input_is_null() {
            var service = new SequenceAnalysisCommand {
                Input = null
            };

            service.OnExecute(_consoleMock.Object);
        }
    }
}