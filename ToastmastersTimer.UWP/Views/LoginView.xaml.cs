using ToastmasterTools.Core.ViewModels;

namespace ToastmastersTimer.UWP.Views
{
    public sealed partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public LoginViewModel ViewModel => DataContext as LoginViewModel;
    }
}