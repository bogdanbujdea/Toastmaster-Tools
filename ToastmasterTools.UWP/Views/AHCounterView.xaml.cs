using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UWP.Views
{
    public sealed partial class AHCounterView
    {
        public AHCounterView()
        {
            InitializeComponent();
        }

        public AHCounterViewModel ViewModel => DataContext as AHCounterViewModel;
    }
}