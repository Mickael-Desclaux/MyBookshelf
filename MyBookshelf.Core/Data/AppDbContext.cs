using Microsoft.EntityFrameworkCore;
using MyBookshelf.Core.Model;

namespace MyBookshelf.Core.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=MyBookshelf.db");
    }
}
