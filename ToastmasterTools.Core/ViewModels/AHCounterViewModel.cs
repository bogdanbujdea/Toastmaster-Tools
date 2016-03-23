using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToastmasterTools.Core.Controls;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class AHCounterViewModel : RoleViewModel
    {
        private readonly IStatisticsService _statisticsService;

        public AHCounterViewModel(IStatisticsService statisticsService, IAppSettings appSettings, IMemberSelector memberSelector) : base(appSettings, memberSelector)
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
            var counter = new Counter { Name = CounterName };
            Counters.Add(counter);
        }

        public void RemoveCounter(string counterName)
        {
            var foundCounter = Counters.FirstOrDefault(c => c.Name == counterName);
            Counters.Remove(foundCounter);
        }

        public async Task SaveSession()
        {

        }
    }
}