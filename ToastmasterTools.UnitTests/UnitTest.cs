using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private AHCounterViewModel _viewModel;

        [TestInitialize]
        public void SetupTests()
        {
            _viewModel = new AHCounterViewModel(null, null, null);
        }

        [TestMethod]
        public void AhCounterShouldHaveAListOfCounters()
        {
            _viewModel.Counters.Count.Should().Be(0);
        }

        [TestMethod]
        public void AddCounter_ShouldIncreaseCountersCount()
        {
            _viewModel.AddCounter();
            _viewModel.Counters.Count.Should().Be(1);
        }

        [TestMethod]
        public void AddCounter_ShouldUseName()
        {
            _viewModel.CounterName = "test";
            _viewModel.AddCounter();
            _viewModel.Counters[0].Name.Should().BeEquivalentTo(_viewModel.CounterName);
        }

        [TestMethod]
        public void Counters_ShouldHaveUniqueName()
        {
            _viewModel.CounterName = "test";
            _viewModel.AddCounter();
            _viewModel.AddCounter();
            _viewModel.Counters.Count.Should().Be(1);
        }

        [TestMethod]
        public void RemoveCounter_ShouldDecreaseCountersCount()
        {
            _viewModel.Counters.Count.Should().Be(0);
            _viewModel.CounterName = "test";
            _viewModel.AddCounter();
            _viewModel.Counters.Count.Should().Be(1);
            _viewModel.RemoveCounter("test");
            _viewModel.Counters.Count.Should().Be(0);
        }

    }
}
