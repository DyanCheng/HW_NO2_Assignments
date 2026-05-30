using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exer4.Models;

namespace Exer4.Pages.Book;

public class DetailModel : PageModel
{
    public Models.Book? Book { get; set; }

    public IActionResult OnGet(int id)
    {
        Book = BookData.Books.FirstOrDefault(b => b.Id == id);
        
        if (Book == null)
        {
            return NotFound();
        }

        return Page();
    }
}
