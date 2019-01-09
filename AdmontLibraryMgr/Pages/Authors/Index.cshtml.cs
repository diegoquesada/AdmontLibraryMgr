using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdmontLibraryMgr.Models;

namespace AdmontLibraryMgr.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly AdmontLibraryMgr.Models.AdmontContext _context;

        public IndexModel(AdmontLibraryMgr.Models.AdmontContext context)
        {
            _context = context;
        }

        public PaginatedList<Author> Author { get;set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            //           Author = await _context.Author.ToListAsync();

            // This queryable object will allow us to sort the list
            // according to the sort criteria passed to the method.
            IQueryable<Author> authorIQ = from a in _context.Author select a;

            int pageSize = 10;
            Author = await PaginatedList<Author>.CreateAsync(authorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
