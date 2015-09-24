using Windows.UI.Xaml.Controls;
using ToastmastersTimer.UWP.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToastmastersTimer.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        public HomeView()
        {
            this.InitializeComponent();
        }

	    public HomeViewModel ViewModel => this.DataContext as HomeViewModel;
    }
}
