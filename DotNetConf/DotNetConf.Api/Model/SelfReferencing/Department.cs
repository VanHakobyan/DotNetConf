using System.Collections.Generic;

namespace DotNetConf.Api.Model.SelfReferencing
{
    public class Department
    {
        public List<StaffMember> StaffMembers { get; set; }
    }
}
