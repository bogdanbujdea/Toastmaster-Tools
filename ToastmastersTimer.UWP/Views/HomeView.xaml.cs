using Windows.UI.Core;
using Template10.Common;
using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Views
{
    public sealed partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();

            Window = WindowWrapper.Current();
            CoreWindow.GetForCurrentThread().VisibilityChanged += OnVisibilityChanged;
        }

        private void OnVisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs args)
        {
            if (args.Visible == false)
                SystemNavigationManager.GetForCurrentView().BackRequested -= BackButtonPressed;
            else
            {
                SystemNavigationManager.GetForCurrentView().BackRequested += BackButtonPressed;
            }
        }

        private void BackButtonPressed(object sender, BackRequestedEventArgs e)
        {
            BootStrapper.Current.Exit();
        }

        private static WindowWrapper Window { get; set; }

        public HomeViewModel ViewModel => this.DataContext as HomeViewModel;
    }
}