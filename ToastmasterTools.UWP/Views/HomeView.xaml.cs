using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using Template10.Common;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UWP.Views
{
    public sealed partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();

            Window = WindowWrapper.Current();
            CoreWindow.GetForCurrentThread().VisibilityChanged += OnVisibilityChanged;
            var currentView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            currentView.SetPreferredMinSize(new Size(500, 500));
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(600, 600);
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

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= BackButtonPressed;
        }

        private void BackButtonPressed(object sender, BackRequestedEventArgs e)
        {
            BootStrapper.Current.Exit();
        }

        private static WindowWrapper Window { get; set; }

        public HomeViewModel ViewModel => this.DataContext as HomeViewModel;
    }
}