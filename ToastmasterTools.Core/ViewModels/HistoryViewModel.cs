using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Navigation;
using Microsoft.Data.Entity;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.Mvvm;

namespace ToastmasterTools.Core.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private readonly IStatisticsService _statisticsService;
        private ObservableCollection<Speech> _speeches;
        private bool _historyIsEmpty;
        private Speech _selectedSpeech;

        public HistoryViewModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
            if (DesignMode.DesignModeEnabled)
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
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await RefreshSpeeches();
            _statisticsService.RegisterPage("HistoryView");
        }

        private async Task RefreshSpeeches()
        {
            using (var db = new ToastmasterContext())
            {
                var speeches = await db.Speeches.Include(s => s.Speaker).Include(s => s.SpeechType).Include(s => s.Counters).ToListAsync();
                Speeches = new ObservableCollection<Speech>(speeches);
            }
            CloseSpeech();
        }

        public void ShowSpeech(Speech speech)
        {
            SelectedSpeech = speech;
        }

        public void CloseSpeech()
        {
            SelectedSpeech = null;
        }

        public async Task DeleteSpeech()
        {
            if (SelectedSpeech != null)
            {
                using (var context = new ToastmasterContext())
                {
                    context.Speeches.Remove(SelectedSpeech);
                    await context.SaveChangesAsync();
                }
                await RefreshSpeeches();
            }
        }

        public async void UpdateSpeech()
        {
            if (SelectedSpeech != null)
            {
                using (var context = new ToastmasterContext())
                {
                    context.Speeches.Update(SelectedSpeech);
                    await context.SaveChangesAsync();
                }
                await RefreshSpeeches();
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

        public Speech SelectedSpeech
        {
            get { return _selectedSpeech; }
            set
            {
                _selectedSpeech = value;
                RaisePropertyChanged();
            }
        }
    }
}
