using FirstApiRepPertten.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApiRepPertten.ApplicationDbCon
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<User> users { get; set; }
    }
}
