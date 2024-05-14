using Microsoft.EntityFrameworkCore;

namespace Jugendretter_API.Entities
{
    public class JugendretterDBContext : DbContext
    {

        public JugendretterDBContext(DbContextOptions<JugendretterDBContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

    }
}
