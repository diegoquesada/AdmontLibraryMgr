using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdmontLibraryMgr.Models;

namespace AdmontLibraryMgr.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly AdmontLibraryMgr.Models.AdmontContext _context;

        public IndexModel(AdmontLibraryMgr.Models.AdmontContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string PublishYearSort { get; set; }
        public string SubjectSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Book> Book { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = sortOrder == "author" ? "author_desc" : "author";
            PublishYearSort = sortOrder == "PublishYear" ? "publishyear_desc" : "publishyear";
            SubjectSort = sortOrder == "Subject" ? "subject_desc" : "subject";

            // If a search string has been provided, reset to page one.
            // Otherwise use our current filter.
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            // This queryable object will allow us to sort the list
            // according to the sort criteria passed to the method.
            IQueryable<Book> bookIQ = from s in _context.Book select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                bookIQ = bookIQ.Where(s => s.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    bookIQ = bookIQ.OrderByDescending(s => s.Title);
                    break;
                case "author":
                    bookIQ = bookIQ.OrderBy(s => s.Author);
                    break;
                case "author_desc":
                    bookIQ = bookIQ.OrderByDescending(s => s.Author);
                    break;
                case "publishyear":
                    bookIQ = bookIQ.OrderBy(s => s.PublishYear);
                    break;
                case "publishyear_desc":
                    bookIQ = bookIQ.OrderByDescending(s => s.PublishYear);
                    break;
                case "subject":
                    bookIQ = bookIQ.OrderBy(s => s.Subject);
                    break;
                case "subject_desc":
                    bookIQ = bookIQ.OrderByDescending(s => s.Subject);
                    break;
                default:
                    bookIQ = bookIQ.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            Book = await PaginatedList<Book>.CreateAsync(bookIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
