using Exer3App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exer3App.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        ViewBag.Message = model.Username == "admin" && model.Password == "123"
            ? "Login success"
            : "Login failed";

        return View(model);
    }
}
