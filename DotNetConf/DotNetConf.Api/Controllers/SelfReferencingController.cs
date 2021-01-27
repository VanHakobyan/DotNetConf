using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DotNetConf.Api.Model.SelfReferencing;

namespace DotNetConf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfReferencingController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var staff = new StaffMember { FirstName = "John Smith" }; //(Really this should actually be calling a repository etc). 
            var department = new Department();
            staff.Department = department;
            department.StaffMembers = new List<StaffMember> { staff };

            return Ok(staff);
        }
    }
}
