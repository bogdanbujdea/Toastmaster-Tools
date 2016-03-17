using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Views
{
    public sealed partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();

            Window = Template10.Common.WindowWrapper.Current();
        }

        private static Template10.Common.WindowWrapper Window { get; set; }

        public HomeViewModel ViewModel => this.DataContext as HomeViewModel;
    }
}