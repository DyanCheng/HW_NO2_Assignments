using Microsoft.AspNetCore.Mvc;
using OrmApp.Data;
using OrmApp.Models;

namespace OrmApp.Controllers;

public class BookController : Controller
{
    private readonly BookRepository _bookRepository;

    public BookController(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_bookRepository.GetAll());
    }

    [HttpGet]
    public IActionResult Detail(int id)
    {
        var book = _bookRepository.GetById(id);
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
    public IActionResult Create(Book model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _bookRepository.Add(model);

        TempData["SuccessMessage"] = "Thêm sách thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var book = _bookRepository.GetById(id);
        if (book is null)
        {
            return NotFound();
        }

        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Book model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!_bookRepository.Update(model))
        {
            return NotFound();
        }

        TempData["SuccessMessage"] = "Cập nhật sách thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var book = _bookRepository.GetById(id);
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
        if (!_bookRepository.Delete(id))
        {
            return NotFound();
        }

        TempData["SuccessMessage"] = "Xóa sách thành công.";
        return RedirectToAction(nameof(Index));
    }
}
