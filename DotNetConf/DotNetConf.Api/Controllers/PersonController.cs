using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DotNetConf.Api.Common;
using DotNetConf.Api.Entity;
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

        /// <summary>
        /// Get person by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = Literal.GetById)]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _service.GetPersonById(id));
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Person>> Create([FromBody] Person person)
        {
            var entity = await _service.AddPerson(person);
            return CreatedAtRoute(Literal.GetById, new { entity.Id }, entity);
        }
    }
}
