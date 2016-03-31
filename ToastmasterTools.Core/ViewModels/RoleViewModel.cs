using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Template10.Mvvm;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Features.SpeechTools;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class RoleViewModel: ViewModelBase
    {
        private readonly IAppSettings _appSettings;
        private IMemberSelector _memberSelector;
        private ISpeechSelector _speechSelector;

        public RoleViewModel(IAppSettings appSettings, IMemberSelector memberSelector, ISpeechSelector speechSelector)
        {
            _appSettings = appSettings;
            speechSelector.Initialize();
            SpeechSelector = speechSelector;
            MemberSelector = memberSelector;
            SelectedSpeechType = new SpeechType { GreenCardTime = new CardTime(), RedCardTime = new CardTime(), YellowCardTime = new CardTime() };
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

        protected Speaker SelectedSpeaker { get; set; }

        public SpeechType SelectedSpeechType { get; set; }

        public bool IsLoggedIn
        {
            get
            {
                var sessionId = _appSettings.Get<string>(StorageKey.SessionId);
                return string.IsNullOrWhiteSpace(sessionId) == false;
            }
        }
    }
}