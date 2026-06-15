using Exer7App.Models;
using Exer7App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exer7App.Controllers;

public class BookController : Controller
{
  private static readonly List<Book> Books =
  [
    new Book
    {
      Id = 1,
      Name = "Clean Code",
      Price = 20,
      ImagePaths = []
    },
    new Book
    {
      Id = 2,
      Name = "ASP.NET MVC",
      Price = 15,
      ImagePaths = []
    },
    new Book
    {
      Id = 3,
      Name = "Design Pattern",
      Price = 25,
      ImagePaths = []
    }
  ];

  private readonly ImageUploadService _imageUploadService;

  public BookController(ImageUploadService imageUploadService)
  {
    _imageUploadService = imageUploadService;
  }

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
  [ValidateAntiForgeryToken]
  public IActionResult Create(Book model, List<IFormFile>? images)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    var uploadFiles = images?.Where(f => f.Length > 0).ToList() ?? [];
    if (uploadFiles.Count > 0)
    {
      var result = _imageUploadService.SaveImages(uploadFiles, "books");
      if (!result.Success)
      {
        ModelState.AddModelError("images", result.ErrorMessage!);
        return View(model);
      }

      model.ImagePaths = result.Paths;
    }

    model.Id = Books.Count == 0 ? 1 : Books.Max(b => b.Id) + 1;
    Books.Add(model);

    TempData["SuccessMessage"] = "Thêm sách thành công.";
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    var book = Books.FirstOrDefault(b => b.Id == id);
    if (book is null)
    {
      return NotFound();
    }

    return View(book);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(Book model, List<IFormFile>? images)
  {
    var book = Books.FirstOrDefault(b => b.Id == model.Id);
    if (book is null)
    {
      return NotFound();
    }

    if (!ModelState.IsValid)
    {
      model.ImagePaths = book.ImagePaths;
      return View(model);
    }

    var uploadFiles = images?.Where(f => f.Length > 0).ToList() ?? [];
    if (uploadFiles.Count > 0)
    {
      var result = _imageUploadService.SaveImages(uploadFiles, "books");
      if (!result.Success)
      {
        ModelState.AddModelError("images", result.ErrorMessage!);
        model.ImagePaths = book.ImagePaths;
        return View(model);
      }

      book.ImagePaths.AddRange(result.Paths);
    }

    book.Name = model.Name;
    book.Price = model.Price;

    TempData["SuccessMessage"] = "Cập nhật sách thành công.";
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    var book = Books.FirstOrDefault(b => b.Id == id);
    if (book is null)
    {
      return NotFound();
    }

    return View(book);
  }

  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public IActionResult DeleteConfirmed(int id)
  {
    var book = Books.FirstOrDefault(b => b.Id == id);
    if (book is null)
    {
      return NotFound();
    }

    Books.Remove(book);

    TempData["SuccessMessage"] = "Xóa sách thành công.";
    return RedirectToAction(nameof(Index));
  }
}
