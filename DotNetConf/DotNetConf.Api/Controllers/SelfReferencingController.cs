using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DotNetConf.Api.Common;
using DotNetConf.Api.Model.SelfReferencing;

namespace DotNetConf.Api.Controllers
{
    /// <summary>
    /// SelfReferencingController
    /// </summary>
    [Route(Literal.ControllerRoute)]
    [ApiController]
    public class SelfReferencingController : ControllerBase
    {
        /// <summary>
        /// Self referencing error
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var staffMember = new StaffMember { FirstName = Literal.JohnSmith }; //(Really this should actually be calling a repository etc). 
            var department = new Department();
            staffMember.Department = department;
            department.StaffMembers = new List<StaffMember> { staffMember };

            return Ok(staffMember);
        }
    }
}
