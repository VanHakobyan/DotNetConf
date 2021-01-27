using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetConf.Api.Entity;

namespace DotNetConf.Api.Service.Interface
{
    public interface IPersonService
    {
        Task<IList<Person>> GetPersons();
    }
}