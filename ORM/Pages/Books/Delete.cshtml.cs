using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using New_folder.Models;
using New_folder.Services;

namespace New_folder.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly IBookService _bookService;

        public DeleteModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _bookService.GetById(id);
            if (Book == null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _bookService.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
