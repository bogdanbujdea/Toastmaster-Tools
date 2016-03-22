using ToastmastersTimer.UWP.Features.Authentication;

namespace ToastmastersTimer.UWP.Models.Reports
{
    public class Report
    {
        public bool Successful { get; }
        public UserData UserData { get; set; }
        public WebError Error { get; set; }
        public string ErrorMessage { get; set; }

        protected Report(bool successful = false)
        {
            Successful = successful;
            ErrorMessage = "Unknown error. Please try again!";
        }
    }
}