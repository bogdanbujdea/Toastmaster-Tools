using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToastmastersTimer.UWP.Models;

namespace ToastmastersTimer.UWP.ViewModels
{
    using Windows.UI.Xaml;

    using Mvvm;

    public class TimerViewModel: ViewModelBase
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
                    GreenCardTime = new Time(4, 0),
                    YellowCardTime = new Time(5, 0),
                    RedCardTime = new Time(6, 0)
			    },
                new Lesson
                {
                    Name = "Standard Breaker",
                    GreenCardTime = new Time(5, 0),
                    YellowCardTime = new Time(6, 00),
                    RedCardTime = new Time(7, 0)
                },
                new Lesson
                {
                    Name = "Advanced Breaker",
                    GreenCardTime = new Time(7, 0),
                    YellowCardTime = new Time(8, 0),
                    RedCardTime = new Time(9, 0)
                },
                new Lesson
                {
                    Name = "Speech Evaluator",
                    GreenCardTime = new Time(2, 0),
                    YellowCardTime = new Time(2, 30),
                    RedCardTime = new Time(3, 0)
                },
                new Lesson
                {
                    Name = "AH Counter",
                    GreenCardTime = new Time(2, 0),
                    YellowCardTime = new Time(2, 30),
                    RedCardTime = new Time(3, 0)
                },
                new Lesson
                {
                    Name = "Gramatician",
                    GreenCardTime = new Time(3, 0),
                    YellowCardTime = new Time(3, 30),
                    RedCardTime = new Time(4, 0)
                },
                new Lesson
                {
                    Name = "Timer",
                    GreenCardTime = new Time(2, 0),
                    YellowCardTime = new Time(2, 30),
                    RedCardTime = new Time(3, 0)
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