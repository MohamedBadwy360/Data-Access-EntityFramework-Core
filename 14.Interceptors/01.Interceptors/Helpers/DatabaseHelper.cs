using C01.BasicSaveWithTracking.Data;
using C01.BasicSaveWithTracking.Entities;
using Microsoft.EntityFrameworkCore;

namespace C01.BasicSaveWithTracking.Helpers
{
    public static class DatabaseHelper
    {
        public static void RecreateCleanDatabase()
        {
            using var context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void PopulateDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.Books.AddRange(new Book[]
                {
                    new Book
                    {
                        Id = 1, 
                        Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                        Author = "Eric Evans"
                    },
                    new Book
                    {
                        Id = 2, 
                        Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries",
                        Author = "Eric Evans"
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "C# In Depth",
                        Author = "John Skeet"
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "Real World Functional Programming",
                        Author = "John Skeet"
                    },
                    new Book
                    {
                        Id = 5,
                        Title = "Grooking Algorithms",
                        Author = "Aditya Bhargava"
                    }
                });


                context.SaveChanges();
            }
        }

        public static void ShowBooks()
        {
            Console.WriteLine();
            Console.WriteLine("Books");
            Console.WriteLine("--------------");

            using var context = new AppDbContext();

            foreach (var book in context.Books)
            {
                var bookTitle = (book.Title.Length >= 11) ? book.Title.Substring(0, 11) : book.Title;
                Console.WriteLine($"Id: {book.Id} \t Title: {bookTitle} \t Author: {book.Author, 20} \t IsDeleted: {book.IsDeleted}");
            }
        }
    }
}
