using System.Threading.Tasks;
using ToastmastersTimer.UWP.Models.Reports;

namespace ToastmastersTimer.UWP.Features.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationReport> Login(string username, string password);
        Task<AuthenticationReport> LoginWithStoredCredentials();
    }
}