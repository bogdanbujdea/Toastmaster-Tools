using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Template10.Mvvm;
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
    public class RoleViewModel : ViewModelBase
    {
        private readonly IAppSettings _appSettings;
        private readonly IDialogService _dialogService;
        private readonly ISpeechRepository _speechRepository;
        private readonly IStatisticsService _statisticsService;
        private IMemberSelector _memberSelector;
        private ISpeechSelector _speechSelector;
        private ObservableCollection<Counter> _counters;
        private string _notes;

        protected RoleViewModel(IAppSettings appSettings, IMemberSelector memberSelector, ISpeechSelector speechSelector, IDialogService dialogService, ISpeechRepository speechRepository, IStatisticsService statisticsService)
        {
            _appSettings = appSettings;
            _dialogService = dialogService;
            _speechRepository = speechRepository;
            _statisticsService = statisticsService;
            speechSelector.Initialize();
            SpeechSelector = speechSelector;
            MemberSelector = memberSelector;
            SelectedSpeechType = new SpeechType { GreenCardTime = new CardTime(), RedCardTime = new CardTime(), YellowCardTime = new CardTime() };
            Counters = new ObservableCollection<Counter>();
            AddDefaultCounters();
        }

        private void AddDefaultCounters()
        {
            AddCounterToList("Ahh");
            AddCounterToList("Pause");
            AddCounterToList("Mmm");
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (IsLoggedIn)
            {
                MemberSelector.SelectedMemberChanged += SelectedMemberChanged;
                SpeechSelector.SelectedSpeechChanged += SelectedSpeechChanged;
                await MemberSelector.InitializeAsync();
                SpeechSelector.Initialize();
            }
        }

        private void SelectedSpeechChanged(object sender, SelectionChangedEventArgs args)
        {
            try
            {
                SelectedSpeechType = args.AddedItems[0] as SpeechType;
            }
            catch (Exception)
            {

            }
        }

        private void SelectedMemberChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedSpeaker = e.AddedItems[0] as Speaker;
            }
            catch (Exception)
            {
            }
        }

        public IMemberSelector MemberSelector
        {
            get { return _memberSelector; }
            set
            {
                _memberSelector = value;
                RaisePropertyChanged();
            }
        }

        public ISpeechSelector SpeechSelector
        {
            get { return _speechSelector; }
            set
            {
                _speechSelector = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Counter> Counters
        {
            get { return _counters; }
            set
            {
                _counters = value;
                RaisePropertyChanged();
            }
        }

        public string CounterName { get; set; }

        public Speaker SelectedSpeaker { get; set; }

        public SpeechType SelectedSpeechType { get; set; }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged();
            }
        }

        public void AddCounter()
        {
            AddCounterToList(CounterName);
        }

        private void AddCounterToList(string name)
        {
            if (Counters.Any(c => c.Name == name && string.IsNullOrWhiteSpace(c.Name) == false))
                return;
            var counter = new Counter {Name = name };
            counter.RemoveCounter += RemoveCounter;
            Counters.Add(counter);
        }

        private void RemoveCounter(object sender, EventArgs e)
        {
            var counter = sender as Counter;
            if (counter != null)
                RemoveCounter(counter.Name);
        }

        public void RemoveCounter(string counterName)
        {
            var foundCounter = Counters.FirstOrDefault(c => c.Name == counterName);
            Counters.Remove(foundCounter);
        }

        protected ReviewerRole ReviewerRole { get; set; }

        protected async Task SaveSessionAsync()
        {
            if (SelectedSpeaker == null)
            {
                await _dialogService.ShowMessageDialog("You must select a speaker!");
                return;
            }
            if (string.IsNullOrWhiteSpace(SelectedSpeechType.Name))
            {
                await _dialogService.ShowMessageDialog("You must select a speech!");
                return;
            }
            var speech = new Speech
            {
                Date = DateTime.Now,
                Counters = Counters.Where(c => string.IsNullOrWhiteSpace(c.Name) == false).ToList(),
                Reviewer = ReviewerRole,
                Notes = Notes
            };
            await _speechRepository.SaveSpeech(speech, SelectedSpeaker.Name, SelectedSpeechType.Name);
            await _dialogService.ShowMessageDialog("The speech was saved!");
            Counters = new ObservableCollection<Counter>();
            AddDefaultCounters();
            Notes = string.Empty;            
            _statisticsService.RegisterEvent(EventCategory.UserEvent, ReviewerRole.ToString(), "saved speech");
        }

        public bool IsLoggedIn
        {
            get
            {
                var sessionId = _appSettings.Get<string>(StorageKey.SessionId);
                return string.IsNullOrWhiteSpace(sessionId) == false;
            }
        }
    }

    public enum ReviewerRole
    {
        Timer,
        AHCounter,
        Grammarian,
        SpeechReviewer
    }
}