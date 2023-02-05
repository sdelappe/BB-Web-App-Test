using Microsoft.EntityFrameworkCore;
using DBConnectionTest.Models;

namespace DBConnectionTest.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
            DBInitializer.Initialize(this);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
