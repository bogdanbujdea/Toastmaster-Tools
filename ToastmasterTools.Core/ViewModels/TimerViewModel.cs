using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Microsoft.Data.Entity;
using ToastmasterTools.Core.Controls;
using ToastmasterTools.Core.Features.Analytics;
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
        private bool _speechUIIsVisible;
        private ObservableCollection<SpeechType> _lessons;
        private SpeechType _selectedSpeechType;

        public TimerViewModel(IStatisticsService statisticsService, IDialogService dialogService, IAppSettings appSettings, IMemberSelector memberSelector) : base(appSettings, memberSelector)
        {
            _statisticsService = statisticsService;
            _dialogService = dialogService;
            SelectedSpeechType = new SpeechType { GreenCardTime = new CardTime(), RedCardTime = new CardTime(), YellowCardTime = new CardTime() };
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            _statisticsService.RegisterPage("TimerView");
            InitializeLessons();
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        private void InitializeLessons()
        {

            Lessons = new ObservableCollection<SpeechType>(ToastmasterContext.ListOfLessons);
            InitializeWithDefaults();
        }

        private void InitializeWithDefaults()
        {
            SelectedSpeechType = Lessons[0];
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
                speech.Date = DateTime.Now;
                using (var context = new ToastmasterContext())
                {
                    await context.DisplayDbData(context);
                    var speaker = await context.Speakers.FirstOrDefaultAsync(s => s.Name == SelectedSpeaker.Name);
                    var speechType =
                        await context.SpeechTypes.FirstOrDefaultAsync(s => s.Name == SelectedSpeechType.Name);
                    speech.Speaker = speaker;
                    speech.SpeechType = speechType;
                    context.Speeches.Add(speech);
                    await context.SaveChangesAsync();
                    await context.DisplayDbData(context);
                }
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

        public ObservableCollection<SpeechType> Lessons
        {
            get { return _lessons; }
            set
            {
                _lessons = value;
                RaisePropertyChanged();
            }
        }

        public SpeechType SelectedSpeechType
        {
            get { return _selectedSpeechType; }
            set
            {
                _selectedSpeechType = value;
                RaisePropertyChanged();
            }
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