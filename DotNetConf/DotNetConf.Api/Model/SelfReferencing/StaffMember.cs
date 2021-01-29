namespace DotNetConf.Api.Model.SelfReferencing
{
    /// <summary>
    /// StaffMember
    /// </summary>
    public class StaffMember
    {
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Department
        /// </summary>
        public Department Department { get; set; }
    }
}
