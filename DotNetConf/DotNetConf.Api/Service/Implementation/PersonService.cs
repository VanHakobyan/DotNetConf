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
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
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

        /// <summary>
        /// GetPersonById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> GetPersonById(int id)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// AddPerson
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<Person> AddPerson(Person person)
        {
            var entityEntry = await _context.AddAsync(person);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}
