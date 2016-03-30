using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.Members
{
    public interface IMemberSelector
    {
        Task InitializeAsync();

        void MemberChanged(SelectionChangedEventArgs args);

        ObservableCollection<Speaker> Members { get; set; }

        event EventHandler<SelectionChangedEventArgs> SelectedMemberChanged;
    }
}