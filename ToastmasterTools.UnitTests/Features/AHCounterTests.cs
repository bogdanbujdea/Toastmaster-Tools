using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace ToastmasterTools.UnitTests.Features
{
    [TestClass]
    public class AHCounterTests
    {
        private Dictionary<Mistake, int> _mistakes;

        [TestInitialize]
        public void InitializeTests()
        {
            _mistakes = new Dictionary<Mistake, int>();
            foreach (var name in Enum.GetValues(typeof (Mistake)))
            {
                _mistakes[(Mistake) name] = 0;
            }
        }

        [TestMethod]
        public void addingMistake_shouldIncreaseCounter()
        {
            AddMistake(Mistake.AH).Should().Be(1);
            AddMistake(Mistake.AH).Should().Be(2);
        }

        [TestMethod]
        public void addingAhMistakes_shouldIncreaseAhCounter()
        {
            AddMistake(Mistake.AH);
            AddMistake(Mistake.AH).Should().Be(2);
        }

        [TestMethod]
        public void addingPauseMistakes_shouldIncreasePauseCounter()
        {
            AddMistake(Mistake.Pause);
            AddMistake(Mistake.Pause).Should().Be(2);
        }

        private int AddMistake(Mistake mistake)
        {
            return ++_mistakes[mistake];
        }
    }

    public enum Mistake
    {
        AH,
        Pause
    }
}
