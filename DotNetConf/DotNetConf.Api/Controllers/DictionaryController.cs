using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using DotNetConf.Api.Common;
using DotNetConf.Api.Entity;
using Microsoft.AspNetCore.Http;

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
        /// Dictionary with non complex key 
        /// </summary>
        /// <response code="200">Dictionary with non complex key 
        ///can convert to System.String.
        /// </response>          
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult Get()
        {
            var dictionary = new Fixture().CreateMany<KeyValuePair<int, string>>(100)
                .ToDictionary(x => x.Key, x => x.Value);

            return Ok(dictionary);
        }

        /// <summary>
        /// Get person fixture, System.NotSupportedException
        /// </summary>
        /// <response code="500">System.Text.Json doesn't deserialize non-string values into string properties.
        /// A non-string value received for a string field results in a JsonException with the following message:
        /// The JSON value could not be converted to System.String.
        /// </response>          
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("person")]
        public ActionResult GetByPersonKey()
        {
            var dictionary = new Fixture().CreateMany<KeyValuePair<Person, string>>(100)
                .ToDictionary(x => x.Key, x => x.Value);

            return Ok(dictionary);
        }
    }
}
