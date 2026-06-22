using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exer4.Models;

namespace Exer4.Pages.Book;

public class CreateModel : PageModel
{
    [BindProperty]
    public Models.Book Book { get; set; } = default!;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Book.Id = BookData.Books.Max(b => b.Id) + 1;
        BookData.Books.Add(Book);

        TempData["SuccessMessage"] = "Thêm sách thành công";
        return RedirectToPage("./Create");
    }
}
