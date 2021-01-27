using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DotNetConf.Api.Common;
using DotNetConf.Api.Model.SelfReferencing;

namespace DotNetConf.Api.Controllers
{
    [Route(Literal.ControllerRoute)]
    [ApiController]
    public class SelfReferencingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var staff = new StaffMember { FirstName = Literal.JohnSmith }; //(Really this should actually be calling a repository etc). 
            var department = new Department();
            staff.Department = department;
            department.StaffMembers = new List<StaffMember> { staff };

            return Ok(staff);
        }
    }
}
