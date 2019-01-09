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
                        Language = "English",
                        PublishYear = 1998,
                        Publisher = "Random House UK",
                        Subject = "Biography",
                        DeweyNumber = "",
                        DateAcquired = DateTime.Parse("2018-10-18"),
                        AuthorID = 1
                    },
                    new Book
                    {
                        Title = "The Popes",
                        Language = "English",
                        PublishYear = 2014,
                        Publisher = "Moseley Road",
                        Subject = "Christianity; Papacy",
                        DeweyNumber = "",
                        DateAcquired = DateTime.Parse("2018-10-18"),
                        AuthorID = 2
                    },
                    new Book
                    {
                        Title = "Dynamics of Software Development",
                        Language = "English",
                        PublishYear = 1995,
                        Publisher = "Microsoft Press",
                        Subject = "Computer software development",
                        DeweyNumber = "005.1'068",
                        DateAcquired = DateTime.Parse("2014-1-1"),
                        AuthorID = 3
                    },
                    new Book
                    {
                        Title = "The Annotated Hans Christian Andersen",
                        Language = "English",
                        PublishYear = 2008,
                        Publisher = "W. W. Norton & Company",
                        Subject = "Fairy tales",
                        DeweyNumber = "",
                        DateAcquired = DateTime.Parse("2018-4-1"),
                        AuthorID = 4
                    }

                );
                context.Author.AddRange(
                    new Author
                    {
                        ID = 1,
                        FirstName = "Peter",
                        LastName = "Ackroyd",
                        DateOfBirth = DateTime.Parse("1949-10-5"),
                        Country = "United Kingdom"
                    },
                    new Author
                    {
                        ID = 2,
                        FirstName = "Rupert",
                        LastName = "Matthews"
                    },
                    new Author
                    {
                        ID = 3,
                        FirstName = "Jim",
                        LastName = "McCarthy"
                    },
                    new Author
                    {
                        ID = 4,
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
