using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using DotNetConf.Api.Common;

namespace DotNetConf.Api.Controllers
{
    /// <summary>
    /// DictionaryController
    /// </summary>
    [Route(Literal.ControllerRoute)]
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
            var dictionary = new Fixture().CreateMany<KeyValuePair<int, string>>(100)
                .ToDictionary(x => x.Key, x => x.Value);

            return Ok(dictionary);
        }
    }
}
