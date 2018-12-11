﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdmontLibraryMgr.Models;

namespace AdmontLibraryMgr.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly AdmontLibraryMgr.Models.AdmontContext _context;

        public DetailsModel(AdmontLibraryMgr.Models.AdmontContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
