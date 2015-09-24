using ToastmastersTimer.UWP.Mvvm;
using ToastmastersTimer.UWP.Views;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
	    public HomeViewModel()
	    {
		    
	    }

	    public void GoToTimerView()
	    {
		    NavigationService.Navigate(typeof (TimerView));
	    }
    }
}