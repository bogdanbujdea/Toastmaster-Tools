using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ToastmasterTools.Core.Features.AHCounter;

namespace ToastmasterTools.UnitTests.Features
{
    [TestClass]
    public class AHCounterTests
    {
        private readonly AHCounter _ahCounter;

        public AHCounterTests()
        {
            _ahCounter = new AHCounter();
        }

        [TestInitialize]
        public void InitializeTests()
        {
           
        }

        [TestMethod]
        public void addingMistake_shouldIncreaseCounter()
        {
            _ahCounter.AddMistake(Mistake.AH).Should().Be(1);
            _ahCounter.AddMistake(Mistake.AH).Should().Be(2);
        }

        [TestMethod]
        public void addingAhMistakes_shouldIncreaseAhCounter()
        {
            _ahCounter.AddMistake(Mistake.AH);
            _ahCounter.AddMistake(Mistake.AH).Should().Be(2);
        }

        [TestMethod]
        public void addingPauseMistakes_shouldIncreasePauseCounter()
        {
            _ahCounter.AddMistake(Mistake.Pause);
            _ahCounter.AddMistake(Mistake.Pause).Should().Be(2);
        }

        [TestMethod]
        public void reset_shouldSetCountersToZero()
        {
            _ahCounter.AddMistake(Mistake.AH);
            _ahCounter.Reset();
            _ahCounter.Mistakes[Mistake.AH].Should().Be(0);
        }
    }
}