using Microsoft.EntityFrameworkCore;
using WorldAPI.Model;

namespace WorldAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions) 
        {

        }
        public DbSet<Country> countries { get; set; }
    }
}
