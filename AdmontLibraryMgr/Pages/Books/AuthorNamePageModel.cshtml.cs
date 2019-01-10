using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdmontLibraryMgr.Models;

namespace AdmontLibraryMgr.Pages.Books
{
    public class AuthorNamePageModel : PageModel
    {
        public SelectList AuthorNameSL { get; set; }

        public void PopulateAuthorsDropDownList(AdmontContext _context, object selectedAuthor = null)
        {
            var authorsQuery = from a in _context.Author
                               orderby a.LastName
                               select a;
            AuthorNameSL = new SelectList(authorsQuery.AsNoTracking(),
                "ID", "LastName", selectedAuthor);
        }
    }
}
