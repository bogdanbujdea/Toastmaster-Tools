using System.Collections.Generic;

namespace ToastmasterTools.Core.Models.Reports
{
    public class MembersReport: Report
    {
        public List<Speaker> Members { get; }

        public MembersReport(bool successful, List<Speaker> members): base(successful)
        {
            Members = members;
        }
    }
}