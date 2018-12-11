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
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }

        public int PublishYear { get; set; }
        public string Publisher { get; set; }

        public string Subject { get; set; }
        public string DeweyNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAcquired { get; set; }
    }
}
