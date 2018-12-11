using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdmontLibraryMgr.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AdmontContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AdmontContext>>()))
            {
                // Look for any books.
                if (context.Book.Any())
                {
                    return;
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "The Life of Thomas More",
                        Author = "Ackroyd, Peter",
                        Language = "English",
                        PublishYear = 1998,
                        Publisher = "Random House UK",
                        Subject = "Biography",
                        DeweyNumber = "",
                        DateAcquired = DateTime.Parse("2018-10-18")
                    },
                    new Book
                    {
                        Title = "The Popes",
                        Author = "Matthews, Rupert",
                        Language = "English",
                        PublishYear = 2014,
                        Publisher = "Moseley Road",
                        Subject = "Christianity; Papacy",
                        DeweyNumber = "",
                        DateAcquired = DateTime.Parse("2018-10-18")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
