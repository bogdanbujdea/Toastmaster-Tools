using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UWP.Views
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