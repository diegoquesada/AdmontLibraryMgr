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
    public class DetailsModel : PageModel
    {
        private readonly AdmontLibraryMgr.Models.AdmontContext _context;

        public DetailsModel(AdmontLibraryMgr.Models.AdmontContext context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
