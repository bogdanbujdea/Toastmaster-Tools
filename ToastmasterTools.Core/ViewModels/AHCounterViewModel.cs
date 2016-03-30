using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Features.SpeechTools;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Features.UserDialogs;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class AHCounterViewModel : RoleViewModel
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IDialogService _dialogService;
        private readonly ISpeechRepository _speechRepository;

        public AHCounterViewModel(IStatisticsService statisticsService, 
            IAppSettings appSettings, 
            IDialogService dialogService, 
            IMemberSelector memberSelector, 
            ISpeechRepository speechRepository,
            ISpeechSelector speechSelector) : base(appSettings, memberSelector, speechSelector)
        {
            _statisticsService = statisticsService;
            _dialogService = dialogService;
            _speechRepository = speechRepository;
            Counters = new ObservableCollection<Counter>
            {
                new Counter {Name = "Ahh", Count = 0},
                new Counter {Name = "Pause", Count = 0},
                new Counter {Name = "Mmm", Count = 0}
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
            if (SelectedSpeaker == null)
            {
                await _dialogService.ShowMessageDialog("You must select a speaker!");
                return;
            }
            var speech = new Speech
            {
                Date = DateTime.Now,
                Counters = Counters.Where(c => string.IsNullOrWhiteSpace(c.Name) == false).ToList()
            };
            await _speechRepository.SaveSpeech(speech, SelectedSpeaker.Name, string.Empty);
            _statisticsService.RegisterEvent(EventCategory.UserEvent, "AH-Counter", "saved speech");
        }
    }
}