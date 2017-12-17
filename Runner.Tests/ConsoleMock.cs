using System.IO;
using McMaster.Extensions.CommandLineUtils;
using Moq;

namespace Runner.Tests {
    internal sealed class ConsoleMock {
        public ConsoleMock() {
            Console = new Mock<IConsole>();
            TextWriter = new Mock<TextWriter>();

            Console.SetupGet(mock => mock.Out).Returns(TextWriter.Object);
        }

        public IConsole Object => Console.Object;

        public Mock<IConsole> Console { get; }

        public Mock<TextWriter> TextWriter { get; }

        public void VerifyWriteLine(string expected) {
            TextWriter.Verify(mock => mock.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
            TextWriter.Verify(mock => mock.WriteLine(expected));
        }
    }
}