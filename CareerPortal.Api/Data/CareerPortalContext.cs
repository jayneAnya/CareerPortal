using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CareerPortal.Data
{
    public class CareerPortalContext : DbContext
    {
        public CareerPortalContext(DbContextOptions<CareerPortalContext> opt) : base(opt)
        {
                
        }

        public DbSet<Command> Commands { get; set; }
    }
}
