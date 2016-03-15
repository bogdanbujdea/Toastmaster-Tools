using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Views
{
    public sealed partial class HomeView
    {
        public HomeView()
        {
            this.InitializeComponent();

            Window = Template10.Common.WindowWrapper.Current();
            Loaded += ViewLoaded;
        }

        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            if (Window == null)
                Window = Template10.Common.WindowWrapper.Current();
        }

        private static Template10.Common.WindowWrapper Window { get; set; }

        public HomeViewModel ViewModel => this.DataContext as HomeViewModel;
    }
}