﻿using C01.BasicSaveWithTracking.Data;
using C01.BasicSaveWithTracking.Entities;
using C01.BasicSaveWithTracking.Helpers;

namespace _01.BasicSaveWithTracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunBasicSave();
            //RunBasicUpdate();
            //RunBasicDelete();
            //RunMultipleOperationsWithSingleSave();
            RunAddDeletedEntities();
        }


        private static void RunBasicSave()
        {
            using (var context = new AppDbContext())
            {
                DatabaseHelper.RecreateCleanDatabase();

                var author = new Author { Id = 1, FName = "Mohamed", LName = "Badwy" };

                context.Authors.Add(author);

                context.SaveChanges();
            }
        }

        private static void RunBasicUpdate()
        {
            using (var context = new AppDbContext())
            {
                var author = context.Authors.Find(1);

                author.FName = "Elsaid";

                context.SaveChanges();
            }
        }

        private static void RunBasicDelete()
        {
            using (var context = new AppDbContext())
            {
                var author = context.Authors.Find(1);

                context.Authors.Remove(author);

                context.SaveChanges();
            }
        }

        private static void RunMultipleOperationsWithSingleSave()
        {
            using (var context = new AppDbContext())
            {
                var author1 = new Author { Id = 1, FName = "Eric", LName = "Evans" };
                context.Authors.Add(author1);

                var author2 = new Author { Id = 2, FName = "John", LName = "Skeet" };
                context.Authors.Add(author2);

                var author3 = new Author { Id = 3, FName = "ditya", LName = "Bhargava" };
                context.Authors.Add(author3);

                author3.FName = "Aditya";

                context.SaveChanges();
            }
        }

        private static void RunAddDeletedEntities()
        {
            using (var context = new AppDbContext())
            {
                var author = context.Authors.Find(1);

                author.Books.Add(new Book
                {
                    Id = 1,
                    Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                });

                context.SaveChanges();
            }
        }
    }
}
