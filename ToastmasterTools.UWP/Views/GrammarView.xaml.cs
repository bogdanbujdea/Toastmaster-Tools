using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UWP.Views
{
    public sealed partial class GrammarView
    {
        public GrammarView()
        {
            InitializeComponent();
        }
        public GrammarViewModel ViewModel => DataContext as GrammarViewModel;
    }
}