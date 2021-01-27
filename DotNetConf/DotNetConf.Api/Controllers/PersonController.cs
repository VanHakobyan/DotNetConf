using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DotNetConf.Api.Common;
using DotNetConf.Api.Service.Interface;

namespace DotNetConf.Api.Controllers
{
    /// <summary>
    /// PersonController
    /// </summary>
    [Route(Literal.ControllerRoute)]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="service"></param>
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _service.GetPersons());
        }
    }
}
