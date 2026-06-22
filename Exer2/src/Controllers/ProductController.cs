using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers;

public class ProductController : Controller
{
    public IActionResult Detail(int? id)
    {
        if (!id.HasValue)
        {
            return Content("Lỗi: Vui lòng cung cấp id sản phẩm (ví dụ: /Product/Detail/5).", "text/plain; charset=utf-8");
        }

        return Content($"Product ID = {id.Value}", "text/plain; charset=utf-8");
    }

    public IActionResult Category(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Content("Lỗi: Vui lòng cung cấp tham số name (ví dụ: /Product/Category?name=Laptop).", "text/plain; charset=utf-8");
        }

        return Content($"Category = {name}", "text/plain; charset=utf-8");
    }
}
