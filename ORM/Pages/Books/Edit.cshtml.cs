using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using New_folder.Models;
using New_folder.Services;

namespace New_folder.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookService _bookService;

        public EditModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return RedirectToPage("Index");
            }

            Book = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookService.Update(Book);
            return RedirectToPage("Index");
        }
    }
}
