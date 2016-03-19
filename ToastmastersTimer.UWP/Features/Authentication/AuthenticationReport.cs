namespace ToastmastersTimer.UWP.Features.Authentication
{
    public class AuthenticationReport
    {
        public bool Successful { get; }
        public UserData UserData { get; set; }
        public WebError Error { get; set; }

        public AuthenticationReport(bool successful = false)
        {
            Successful = successful;
        }
    }
}