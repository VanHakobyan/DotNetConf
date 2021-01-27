using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoFixture;
using DotNetConf.Api.Model.HealthCheck;
using DotNetConf.Api.Model.SelfReferencing;

namespace DotNetConf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        /// <summary>
        /// Dictionary error
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            var dictionary = new Fixture().CreateMany<KeyValuePair<int, HealthCheck>>(100)
                .ToDictionary(x => x.Key, x => x.Value);
            
            return Ok(dictionary);
        }
    }
}
