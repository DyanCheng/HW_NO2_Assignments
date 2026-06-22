using Microsoft.AspNetCore.Mvc.RazorPages;
using New_folder.Models;
using New_folder.Services;

namespace New_folder.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;

        public IndexModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IEnumerable<Book> Books { get; private set; } = Enumerable.Empty<Book>();

        public void OnGet()
        {
            Books = _bookService.GetAll();
        }
    }
}
