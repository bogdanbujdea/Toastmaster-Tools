using System.Collections.Generic;
using System.Threading.Tasks;
using ToastmastersTimer.UWP.Models.Reports;

namespace ToastmastersTimer.UWP.Features.Members
{
    public interface IMembersRepository
    {
        Task<MembersReport> RetrieveClubMembers();

        Task<MembersReport> RefreshClubMembers();
    }
}