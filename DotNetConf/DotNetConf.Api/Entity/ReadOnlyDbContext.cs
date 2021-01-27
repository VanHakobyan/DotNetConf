using Microsoft.EntityFrameworkCore;

namespace DotNetConf.Api.Entity
{
    public class ReadOnlyDbContext : DotNetConfContext
    {
        public ReadOnlyDbContext(DbContextOptions<DotNetConfContext> options)
            : base(options)
        {
        }
    }
}
