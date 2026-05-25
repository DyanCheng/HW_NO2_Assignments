using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers;

public class HomeController : Controller
{
    private const string StudentName = "Nguyễn Văn A";
    private const string StudentEmail = "nguyenvana@student.edu.vn";

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewData["StudentName"] = StudentName;
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["StudentEmail"] = StudentEmail;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
