namespace DotNetConf.Api.Model.SelfReferencing
{
    /// <summary>
    /// StaffMember
    /// </summary>
    public class StaffMember
    {
        public string FirstName { get; set; }
        public Department Department { get; set; }
    }
}
