using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models;

namespace New_folder.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _context;

        public BookService(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll() => _context.Books.AsNoTracking().OrderBy(b => b.Id).ToList();

        public Book? GetById(int id) => _context.Books.Find(id);

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            var existing = _context.Books.Find(book.Id);
            if (existing == null)
            {
                return;
            }

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Description = book.Description;
            existing.Year = book.Year;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
