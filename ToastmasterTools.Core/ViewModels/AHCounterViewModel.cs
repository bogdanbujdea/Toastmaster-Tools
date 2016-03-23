using System.Collections.ObjectModel;
using System.Linq;
using Template10.Mvvm;
using ToastmasterTools.Core.Features.Analytics;

namespace ToastmasterTools.Core.ViewModels
{
    public class AHCounterViewModel: ViewModelBase
    {
        private readonly IStatisticsService _statisticsService;

        public AHCounterViewModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
            Counters = new ObservableCollection<Counter>
            {
                new Counter {Name = "AH", Count = 12},
                new Counter {Name = "Pause", Count = 3},
                new Counter {Name = "Mmm", Count = 0},
                new Counter {Name = "ABC", Count = 20},
            };
        }

        public ObservableCollection<Counter> Counters { get; set; }

        public string CounterName { get; set; }

        public void AddCounter()
        {
            if (Counters.Any(c => c.Name == CounterName))
                return;
            var counter = new Counter {Name = CounterName};
            Counters.Add(counter);
        }

        public void RemoveCounter(string counterName)
        {
            var foundCounter = Counters.FirstOrDefault(c => c.Name == counterName);
            Counters.Remove(foundCounter);
        }
    }

    public class Counter
    {
        public int Count { get; set; }
        public string Name { get; set; }
    }
}