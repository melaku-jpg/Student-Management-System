using Microsoft.EntityFrameworkCore;
using Student.Models;
namespace Student.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Students> students { get; set; }
    }
}
