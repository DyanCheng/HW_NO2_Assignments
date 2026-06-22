using Microsoft.EntityFrameworkCore;
using OrmApp.Models;

namespace OrmApp.Data;

/// <summary>
/// Thực hiện các thao tác CRUD với bảng Book qua Entity Framework Core (ORM).
/// </summary>
public class BookRepository
{
    private readonly BookDbContext _context;

    public BookRepository(BookDbContext context)
    {
        _context = context;
    }

    public List<Book> GetAll()
    {
        return _context.Books
            .AsNoTracking()
            .OrderBy(b => b.Id)
            .ToList();
    }

    public Book? GetById(int id)
    {
        return _context.Books
            .AsNoTracking()
            .FirstOrDefault(b => b.Id == id);
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public bool Update(Book book)
    {
        var existing = _context.Books.Find(book.Id);
        if (existing is null)
        {
            return false;
        }

        existing.Name = book.Name;
        existing.Price = book.Price;

        return _context.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var book = _context.Books.Find(id);
        if (book is null)
        {
            return false;
        }

        _context.Books.Remove(book);
        return _context.SaveChanges() > 0;
    }
}
