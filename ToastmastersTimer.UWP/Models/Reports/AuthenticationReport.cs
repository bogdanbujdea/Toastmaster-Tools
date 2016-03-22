using ToastmastersTimer.UWP.Features.Authentication;

namespace ToastmastersTimer.UWP.Models.Reports
{
    public class AuthenticationReport: Report
    {
        public AuthenticationReport(bool successful = false): base(successful)
        {
        }
    }
}