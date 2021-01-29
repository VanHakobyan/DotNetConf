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

        /// <summary>
        /// AddPerson
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<Person> AddPerson(Person person);

        /// <summary>
        /// GetPersonById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Person> GetPersonById(int id);
    }
}