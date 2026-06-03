using Exer3App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exer3App.Controllers;

public class BookController : Controller
{
    private static readonly List<Book> Books =
    [
        new Book { Id = 1, Name = "Clean Code", Price = 20 },
        new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
        new Book { Id = 3, Name = "Design Pattern", Price = 25 }
    ];

    [HttpGet]
    public IActionResult Index()
    {
        return View(Books);
    }

    [HttpGet]
    public IActionResult Detail(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book is null)
        {
            return NotFound();
        }

        return View(book);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = Books.Max(b => b.Id) + 1;
        Books.Add(model);

        TempData["SuccessMessage"] = "Thêm sách thành công";
        return RedirectToAction(nameof(Create));
    }
}
