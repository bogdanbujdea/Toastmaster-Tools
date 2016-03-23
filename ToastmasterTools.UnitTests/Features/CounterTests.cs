using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ToastmasterTools.Core.Features.AHCounter;

namespace ToastmasterTools.UnitTests.Features
{
    [TestClass]
    public class CounterTests
    {
        private readonly Counter _counter;

        public CounterTests()
        {
            _counter = new Counter();
        }

        [TestInitialize]
        public void InitializeTests()
        {
           
        }

        [TestMethod]
        public void addingMistake_shouldIncreaseCounter()
        {
            _counter.Count++;
            _counter.Count++;
            _counter.Count.Should().Be(2);
        }

        [TestMethod]
        public void decreaseCount_shouldNotGoBelowZero()
        {
            _counter.Count = 0;
            _counter.Count--;
            _counter.Count.Should().Be(0);
        }
    }
}