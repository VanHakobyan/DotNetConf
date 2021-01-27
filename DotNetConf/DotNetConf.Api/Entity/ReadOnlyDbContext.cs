using Microsoft.EntityFrameworkCore;

namespace DotNetConf.Api.Entity
{
    /// <summary>
    /// ReadOnlyDbContext
    /// </summary>
    public class ReadOnlyDbContext : DotNetConfContext
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="options"></param>
        public ReadOnlyDbContext(DbContextOptions<DotNetConfContext> options)
            : base(options)
        {
        }
    }
}
