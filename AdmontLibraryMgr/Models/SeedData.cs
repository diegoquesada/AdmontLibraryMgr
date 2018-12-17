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
                    },
                    new Book
                    {
                        Title = "Dynamics of Software Development",
                        Author = "McCarthy, Jim",
                        Language = "English",
                        PublishYear = 1995,
                        Publisher = "Microsoft Press",
                        Subject = "Computer software development",
                        DeweyNumber = "005.1'068",
                        DateAcquired = DateTime.Parse("2014-1-1")
                    },
                    new Book
                    {
                        Title = "The Annotated Hans Christian Andersen",
                        Author = "Andersen, Hans Christian",
                        Language = "English",
                        PublishYear = 2008,
                        Publisher = "W. W. Norton & Company",
                        Subject = "Fairy tales",
                        DeweyNumber = "",
                        DateAcquired = DateTime.Parse("2018-4-1")
                    }

                );
                context.Author.AddRange(
                    new Author
                    {
                        FirstName = "Peter",
                        LastName = "Ackroyd",
                        DateOfBirth = DateTime.Parse("1949-10-5"),
                        Country = "United Kingdom"
                    },
                    new Author
                    {
                        FirstName = "Rupert",
                        LastName = "Matthews"
                    },
                    new Author
                    {
                        FirstName = "Jim",
                        LastName = "McCarthy"
                    },
                    new Author
                    {
                        FirstName = "Hans Christian",
                        LastName = "Andersen",
                        DateOfBirth = DateTime.Parse("1805-04-02"),
                        Country = "Denmark"
                    });
                context.SaveChanges();
            }
        }
    }
}
