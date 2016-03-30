using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Features.Members;

namespace ToastmasterTools.Core.Controls
{
    public sealed partial class ToastmasterMemberPicker
    {
        public ToastmasterMemberPicker()
        {
            InitializeComponent();
        }

        public MemberSelector ViewModel => DataContext as MemberSelector;

        private void SelectedMemberChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.MemberChanged(e);
        }
    }
}