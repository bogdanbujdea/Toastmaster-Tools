using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Views
{
    public sealed partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public LoginViewModel LoginViewModel => DataContext as LoginViewModel;
    }
}