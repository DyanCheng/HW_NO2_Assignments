using Microsoft.EntityFrameworkCore;
using New_folder.Models;

namespace New_folder.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}
