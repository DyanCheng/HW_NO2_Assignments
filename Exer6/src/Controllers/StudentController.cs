using Exer6App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exer6App.Controllers;

public class StudentController : Controller
{
    private static readonly List<Student> Students =
    [
        new Student { Id = 1, Name = "Nguyễn Văn A", Email = "nguyenvana@email.com", Phone = "0901234567" },
        new Student { Id = 2, Name = "Trần Thị B", Email = "tranthib@email.com", Phone = "0912345678" },
        new Student { Id = 3, Name = "Lê Văn C", Email = "levanc@email.com", Phone = "0923456789" }
    ];

    [HttpGet]
    public IActionResult Index()
    {
        return View(Students);
    }

    [HttpGet]
    public IActionResult Detail(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = Students.Count == 0 ? 1 : Students.Max(s => s.Id) + 1;
        Students.Add(model);

        TempData["SuccessMessage"] = "Thêm sinh viên thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Student model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var student = Students.FirstOrDefault(s => s.Id == model.Id);
        if (student is null)
        {
            return NotFound();
        }

        student.Name = model.Name;
        student.Email = model.Email;
        student.Phone = model.Phone;

        TempData["SuccessMessage"] = "Cập nhật sinh viên thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        Students.Remove(student);

        TempData["SuccessMessage"] = "Xóa sinh viên thành công.";
        return RedirectToAction(nameof(Index));
    }
}
