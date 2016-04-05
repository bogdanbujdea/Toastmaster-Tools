using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UWP.Views
{
    public sealed partial class HistoryView
    {
        public HistoryView()
        {
            InitializeComponent();
        }

        public HistoryViewModel ViewModel { get; set; }
    }
}