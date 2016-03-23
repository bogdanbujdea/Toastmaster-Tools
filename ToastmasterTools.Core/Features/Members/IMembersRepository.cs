using System.Threading.Tasks;
using ToastmasterTools.Core.Models.Reports;

namespace ToastmasterTools.Core.Features.Members
{
    public interface IMembersRepository
    {
        Task<MembersReport> RetrieveClubMembers();

        Task<MembersReport> RefreshClubMembers();
    }
}