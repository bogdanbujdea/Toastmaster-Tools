using System.Collections.Generic;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.Core.Models.Reports
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