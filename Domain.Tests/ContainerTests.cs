using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests {
    [TestClass]
    public sealed class ContainerTests {
        [TestMethod]
        public void Should_return_instance_of_SumOfMultiple() {
            var actual = Container.GetService<ISumOfMultiple>();

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(SumOfMultiple));
        }

        [TestMethod]
        public void Should_return_instance_of_SequenceAnalysis() {
            var actual = Container.GetService<ISequenceAnalysis>();

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(SequenceAnalysis));
        }
    }
}