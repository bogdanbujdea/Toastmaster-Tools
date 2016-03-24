using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Template10.Mvvm;
using ToastmasterTools.Core.Controls;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class RoleViewModel: ViewModelBase
    {
        private readonly IAppSettings _appSettings;
        private IMemberSelector _memberSelector;

        public RoleViewModel(IAppSettings appSettings, IMemberSelector memberSelector)
        {
            _appSettings = appSettings;
            _memberSelector = memberSelector;
            MemberSelector = memberSelector;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (IsLoggedIn)
            {
                MemberSelector.SelectedMemberChanged += SelectedMemberChanged;
                await MemberSelector.InitializeAsync();
            }
        }

        private void SelectedMemberChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedMember = e.AddedItems[0] as Member;
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

        protected Member SelectedMember { get; set; }

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