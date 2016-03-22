using System.Collections.Generic;
using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Models.Reports
{
    public class MembersReport: Report
    {
        public List<Member> Members { get; }

        public MembersReport(bool successful, List<Member> members): base(successful)
        {
            Members = members;
        }
    }
}