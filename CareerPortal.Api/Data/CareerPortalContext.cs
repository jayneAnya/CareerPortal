using CareerPortal.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CareerPortal.Data
{
    public class CareerPortalContext : DbContext
    {
        public CareerPortalContext(DbContextOptions<CareerPortalContext> options)
             : base(options)
        {
        }
       

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CandidateInformation> CandidateInformations { get; set; }


    }
}
