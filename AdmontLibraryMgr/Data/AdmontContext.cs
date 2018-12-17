using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdmontLibraryMgr.Models;

namespace AdmontLibraryMgr.Models
{
    public class AdmontContext : DbContext
    {
        public AdmontContext (DbContextOptions<AdmontContext> options)
            : base(options)
        {
        }

        public DbSet<AdmontLibraryMgr.Models.Book> Book { get; set; }

        public DbSet<AdmontLibraryMgr.Models.Author> Author { get; set; }
    }
}
