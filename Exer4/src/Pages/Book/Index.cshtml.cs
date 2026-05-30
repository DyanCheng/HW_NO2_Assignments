using Microsoft.AspNetCore.Mvc.RazorPages;
using Exer4.Models;

namespace Exer4.Pages.Book;

public class IndexModel : PageModel
{
    public List<Models.Book> Books { get; set; } = new();

    public void OnGet()
    {
        Books = BookData.Books;
    }
}
