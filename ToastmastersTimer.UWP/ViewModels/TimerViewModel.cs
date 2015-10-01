using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToastmastersTimer.UWP.Models;

namespace ToastmastersTimer.UWP.ViewModels
{
    using Windows.UI.Xaml;

    using Mvvm;

    public class TimerViewModel : ViewModelBase
    {
        private bool _speechUIIsVisible;
        private ObservableCollection<Lesson> _lessons;
        private Lesson _selectedLesson;

        public TimerViewModel()
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
            SelectedLesson = Lessons[0];
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