using System.Collections.Generic;

namespace DotNetConf.Api.Model.SelfReferencing
{
    /// <summary>
    /// Department
    /// </summary>
    public class Department
    {
        public List<StaffMember> StaffMembers { get; set; }
    }
}
