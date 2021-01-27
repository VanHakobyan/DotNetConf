using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetConf.Api.Entity;

namespace DotNetConf.Api.Service.Interface
{
    /// <summary>
    /// IPersonService
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// GetPersons
        /// </summary>
        /// <returns></returns>
        Task<IList<Person>> GetPersons();
    }
}