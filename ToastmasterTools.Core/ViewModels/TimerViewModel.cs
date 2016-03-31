using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Features.SpeechTools;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Features.UserDialogs;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class TimerViewModel : RoleViewModel
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IDialogService _dialogService;
        private readonly ISpeechRepository _speechRepository;
        private bool _speechUIIsVisible;

        public TimerViewModel(IStatisticsService statisticsService, IDialogService dialogService, 
            IAppSettings appSettings, IMemberSelector memberSelector, ISpeechRepository speechRepository, ISpeechSelector speechSelector) : base(appSettings, memberSelector, speechSelector)
        {
            _statisticsService = statisticsService;
            _dialogService = dialogService;
            _speechRepository = speechRepository;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await base.OnNavigatedToAsync(parameter, mode, state);
            _statisticsService.RegisterPage("TimerView");
            InitializeWithDefaults();
        }

        private void InitializeWithDefaults()
        {
            SelectedSpeechType = SpeechSelector.Lessons[0];
            SelectLesson();
        }

        public void SetTimer(object element, DataContextChangedEventArgs context)
        {
            Timer = context.NewValue as ToastmastersTimerViewModel;
            Timer.SpeechStopped += SaveSpeech;
        }

        private async void SaveSpeech(object sender, Speech speech)
        {
            var saveSpeech = await _dialogService.AskQuestion("Do you want to save this speech?");
            if (saveSpeech)
            {
                await _speechRepository.SaveSpeech(speech, SelectedSpeaker.Name, SelectedSpeechType.Name);
            }
            InitializeWithDefaults();
            Timer.Reset();
        }

        public void ShowSpeechUI()
        {
            SpeechUIIsVisible = true;
        }

        public void SelectLesson()
        {
            SpeechUIIsVisible = false;

            Timer.CurrentSpeech = new Speech
            {
                SpeechType = SelectedSpeechType,
                Date = DateTime.Now
            };
        }

        public bool SpeechUIIsVisible
        {
            get { return _speechUIIsVisible; }
            set
            {
                _speechUIIsVisible = value;
                RaisePropertyChanged();
            }
        }

        public ToastmastersTimerViewModel Timer { get; set; }
    }
}