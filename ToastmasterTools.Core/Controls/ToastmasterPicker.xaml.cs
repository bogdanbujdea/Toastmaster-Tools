using Windows.UI.Xaml.Controls;

namespace ToastmasterTools.Core.Controls
{
    public sealed partial class ToastmasterPicker
    {
        public ToastmasterPicker()
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