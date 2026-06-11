using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using New_folder.Models;
using New_folder.Services;

namespace New_folder.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBookService _bookService;

        public DetailsModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Book? Book { get; private set; }

        public IActionResult OnGet(int id)
        {
            Book = _bookService.GetById(id);
            if (Book == null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
