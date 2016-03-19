using System.Threading.Tasks;

namespace ToastmastersTimer.UWP.Features.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationReport> Login(string username, string password);
    }
}