using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdmontLibraryMgr.Models
{
    public class Book
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        public string Language { get; set; }

        [Range(1000, 2500)]
        [Display(Name = "Year of Publication")]
        public int PublishYear { get; set; }

        public string Publisher { get; set; }

        public string Subject { get; set; }

        [Display(Name = "Dewey Number")]
        public string DeweyNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Acquired")]
        public DateTime DateAcquired { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
