using System.Threading.Tasks;
using ToastmasterTools.Core.Models.Reports;

namespace ToastmasterTools.Core.Features.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationReport> Login(string username, string password);
        Task<AuthenticationReport> LoginWithStoredCredentials();
    }
}