using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ToastmastersTimer.UWP.Features.Analytics;
using ToastmastersTimer.UWP.Features.Members;
using ToastmastersTimer.UWP.Features.UserDialogs;
using ToastmastersTimer.UWP.Models;
using ToastmastersTimer.UWP.Services.SettingsServices;

namespace ToastmastersTimer.UWP.ViewModels
{
    using Windows.UI.Xaml;

    using Mvvm;

    public class TimerViewModel : ViewModelBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IMembersRepository _membersRepository;
        private readonly IDialogService _dialogService;
        private readonly IAppSettings _appSettings;
        private bool _speechUIIsVisible;
        private ObservableCollection<Lesson> _lessons;
        private Lesson _selectedLesson;
        private ObservableCollection<Member> _members;

        public TimerViewModel(IStatisticsService statisticsService, IMembersRepository membersRepository, IDialogService dialogService, IAppSettings appSettings)
        {
            _statisticsService = statisticsService;
            _membersRepository = membersRepository;
            _dialogService = dialogService;
            _appSettings = appSettings;
            InitializeLessons();
            SelectedLesson = Lessons[0];
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (IsLoggedIn)
            {
                var report = await _membersRepository.RefreshClubMembers();
                if (report.Successful)
                    Members = new ObservableCollection<Member>(report.Members);
                else await _dialogService.AskQuestion(report.ErrorMessage);
            }
            _statisticsService.RegisterPage("TimerView");
        }

        private void InitializeLessons()
        {
            Lessons = new ObservableCollection<Lesson>
            {
                new Lesson
                {
                    Name = "Ice Breaker",
                    GreenCardTime = new CardTime(4, 0),
                    YellowCardTime = new CardTime(5, 0),
                    RedCardTime = new CardTime(6, 0)
                },
                new Lesson
                {
                    Name = "Standard Breaker",
                    GreenCardTime = new CardTime(5, 0),
                    YellowCardTime = new CardTime(6, 00),
                    RedCardTime = new CardTime(7, 0)
                },
                new Lesson
                {
                    Name = "Advanced Breaker",
                    GreenCardTime = new CardTime(7, 0),
                    YellowCardTime = new CardTime(8, 0),
                    RedCardTime = new CardTime(9, 0)
                },
                new Lesson
                {
                    Name = "Speech Evaluator",
                    GreenCardTime = new CardTime(2, 0),
                    YellowCardTime = new CardTime(2, 30),
                    RedCardTime = new CardTime(3, 0)
                },
                new Lesson
                {
                    Name = "AH Counter",
                    GreenCardTime = new CardTime(2, 0),
                    YellowCardTime = new CardTime(2, 30),
                    RedCardTime = new CardTime(3, 0)
                },
                new Lesson
                {
                    Name = "Gramatician",
                    GreenCardTime = new CardTime(3, 0),
                    YellowCardTime = new CardTime(3, 30),
                    RedCardTime = new CardTime(4, 0)
                },
                new Lesson
                {
                    Name = "Timer",
                    GreenCardTime = new CardTime(2, 0),
                    YellowCardTime = new CardTime(2, 30),
                    RedCardTime = new CardTime(3, 0)
                },
            };
        }

        public void SetTimer(object element, DataContextChangedEventArgs context)
        {
            Timer = context.NewValue as ToastmastersTimerViewModel;
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
                Lesson = SelectedLesson
            };
        }

        public bool IsLoggedIn
        {
            get
            {
                var sessionId = _appSettings.Get<string>(StorageKey.SessionId);
                return string.IsNullOrWhiteSpace(sessionId) == false;
            }
        }

        public ObservableCollection<Member> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                RaisePropertyChanged();
            }
        }


        public ObservableCollection<Lesson> Lessons
        {
            get { return _lessons; }
            set
            {
                _lessons = value;
                RaisePropertyChanged();
            }
        }

        public Lesson SelectedLesson
        {
            get { return _selectedLesson; }
            set
            {
                _selectedLesson = value;
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