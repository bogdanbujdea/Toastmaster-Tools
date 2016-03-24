using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.Core.Controls
{
    public interface IMemberSelector
    {
        Task InitializeAsync();

        void MemberChanged(SelectionChangedEventArgs args);

        ObservableCollection<Member> Members { get; set; }

        event EventHandler<SelectionChangedEventArgs> SelectedMemberChanged;
    }
}