using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdmontLibraryMgr.Models;

namespace AdmontLibraryMgr.Pages.Books
{
    public class CreateModel : AuthorNamePageModel
    {
        private readonly AdmontLibraryMgr.Models.AdmontContext _context;

        public CreateModel(AdmontLibraryMgr.Models.AdmontContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateAuthorsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyBook = new Book();

            if (await TryUpdateModelAsync<Book>(
                emptyBook,
                "book",
                s => s.ID, s => s.AuthorID, s => s.Title, s => s.PublishYear))
            {
                _context.Book.Add(emptyBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAuthorsDropDownList(_context, emptyBook.AuthorID);
            return Page();
        }
    }
}