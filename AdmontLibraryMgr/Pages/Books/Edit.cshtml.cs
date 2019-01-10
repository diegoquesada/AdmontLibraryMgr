using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdmontLibraryMgr.Models;

namespace AdmontLibraryMgr.Pages.Books
{
    public class EditModel : AuthorNamePageModel
    {
        private readonly AdmontLibraryMgr.Models.AdmontContext _context;

        public EditModel(AdmontLibraryMgr.Models.AdmontContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Author).FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            PopulateAuthorsDropDownList(_context, Book.AuthorID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bookToUpdate = await _context.Book.FindAsync(id);

            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "book",
                b => b.Title, b => b.AuthorID, b => b.Language, b => b.PublishYear, b => b.Publisher, b => b.Subject, b => b.DeweyNumber, b => b.DateAcquired))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAuthorsDropDownList(_context, bookToUpdate.AuthorID);
            return Page();
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
