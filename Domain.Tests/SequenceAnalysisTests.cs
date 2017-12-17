using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests {
    [TestClass]
    public sealed class SequenceAnalysisTests {
        [TestMethod]
        [DataRow("This IS a STRING", "GIINRSSTT")]
        [DataRow("Caliel Lima da Costa", "CCL")]
        [DataRow("THIS is a STriNG", "GHINSSTT")]
        [DataRow("I am Brazilian", "BI")]
        [DataRow("RbBDwjKtIsWGFgLEyVYMmxqnikTAepUQXPHvhOlJNuScadCrZofz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [DataRow("text", "")]
        [DataRow("", "")]
        public void Should_return_uppercase_words_alphabetically(string input, string expected) {
            var service = new SequenceAnalysis();
            var actual = service.Execute(input);

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_when_input_is_null() {
            var service = new SequenceAnalysis();
            var unused = service.Execute(null);
        }
    }
}
