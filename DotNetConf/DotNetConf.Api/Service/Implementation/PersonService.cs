using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetConf.Api.Entity;
using DotNetConf.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace DotNetConf.Api.Service.Implementation
{
    /// <summary>
    /// Person service
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly DotNetConfContext _context;
        public PersonService(DotNetConfContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Person>> GetPersons()
        {
            return await _context.People.ToListAsync();
        }
    }
}
