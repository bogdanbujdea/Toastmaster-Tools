using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Microsoft.Data.Entity;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.Mvvm;

namespace ToastmasterTools.Core.ViewModels
{
    public class HistoryViewModel: ViewModelBase
    {
        private ObservableCollection<Speech> _speeches;
        private bool _historyIsEmpty;

        public HistoryViewModel()
        {
            Speeches = new ObservableCollection<Speech>
            {
                new Speech
                {
                    Speaker = new Speaker {Name = "Bogdan Bujdea", CurrentLesson = "Ice Breaker"},
                    SpeechType = new SpeechType {Name = "Ice Breaker"},
                    Notes = "Good speech",
                    SpeechTimeInSeconds = 500,
                    Date = DateTime.Now                    
                },
                new Speech
                {
                    Speaker = new Speaker {Name = "Alex Popa", CurrentLesson = "Ice Breaker"},
                    SpeechType = new SpeechType {Name = "STandard Breaker"},
                    Notes = "Bad speech",
                    SpeechTimeInSeconds = 1500,
                    Date = DateTime.Now.Subtract(TimeSpan.FromDays(3))
                },
                new Speech
                {
                    Speaker = new Speaker {Name = "Emilian Padurariu", CurrentLesson = "Ice Breaker"},
                    SpeechType = new SpeechType {Name = "Advanced Breaker"},
                    Notes = "Good good speech",
                    SpeechTimeInSeconds = 400,
                    Date = DateTime.Now
                },
                new Speech
                {
                    Speaker = new Speaker {Name = "Bogdan Bujdea", CurrentLesson = "Ice Breaker"},
                    SpeechType = new SpeechType {Name = "Ice Breaker"},
                    Notes = "Good speech",
                    SpeechTimeInSeconds = 500,
                    Date = DateTime.Now
                },
                new Speech
                {
                    Speaker = new Speaker {Name = "Bogdan Bujdea", CurrentLesson = "Ice Breaker"},
                    SpeechType = new SpeechType {Name = "Ice Breaker"},
                    Notes = "Good speech",
                    SpeechTimeInSeconds = 500,
                    Date = DateTime.Now
                }
            };
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            using (var db = new ToastmasterContext())
            {
                var speeches = await db.Speeches.Include(s => s.Speaker).Include(s => s.SpeechType).ToListAsync();
                Speeches = new ObservableCollection<Speech>(speeches);
            }
        }

        public ObservableCollection<Speech> Speeches
        {
            get { return _speeches; }
            set
            {
                _speeches = value;
                HistoryIsEmpty = _speeches.Count == 0;
                RaisePropertyChanged();
            }
        }

        public bool HistoryIsEmpty
        {
            get { return _historyIsEmpty; }
            set
            {
                _historyIsEmpty = value;
                RaisePropertyChanged();
            }
        }
    }
}
