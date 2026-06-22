using System.ComponentModel.DataAnnotations;

namespace Exer4.Models;

public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Không được để trống")]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal Price { get; set; }
}

public static class BookData
{
    public static List<Book> Books { get; } = new List<Book>
    {
        new Book { Id = 1, Name = "Clean Code", Price = 20 },
        new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
        new Book { Id = 3, Name = "Design Pattern", Price = 25 }
    };
}
