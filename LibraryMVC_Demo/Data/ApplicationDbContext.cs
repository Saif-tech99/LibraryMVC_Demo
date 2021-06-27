using LibraryMVC_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Genre> genres { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Name = "Sci-Fi" },
                new Genre() { GenreId = 2, Name = "Psychological" },
                new Genre() { GenreId = 3, Name = "Drame" },
                new Genre() { GenreId = 4, Name = "Mystery" },
                new Genre() { GenreId = 5, Name = "Thriller" },
                new Genre() { GenreId = 6, Name = "Seinen" });

            modelBuilder.Entity<Author>().HasData(
                new Author() { AuthorId = 1, AuthorName = "Shirow Masamune " },
                new Author() { AuthorId = 2, AuthorName = "Hitoshi Iwaaki" },
                new Author() { AuthorId = 3, AuthorName = "Yoshitoki Oima" },
                new Author() { AuthorId = 4, AuthorName = "Yana Toboso" },
                new Author() { AuthorId = 5, AuthorName = "Kudan Naduka" },
                new Author() { AuthorId = 6, AuthorName = "Sun Takeda" });

            modelBuilder.Entity<Book>().HasData(
                new Book() { BookId = 1, Title = "The Ghost in the Shell", AuthorId = 1, GenreId = 1, DateOfPublishing = new DateTime(2008, 09, 17) },
                new Book() { BookId = 2, Title = "Parasyte", AuthorId = 2, GenreId = 2, DateOfPublishing = new DateTime(2008, 07, 17) },
                new Book() { BookId = 3, Title = "A Silent Voice", AuthorId = 3, GenreId = 3, DateOfPublishing = new DateTime(2014, 06, 17) },
                new Book() { BookId = 4, Title = "Black Butler", AuthorId = 4, GenreId = 4, DateOfPublishing = new DateTime(2010, 02, 17) },
                new Book() { BookId = 5, Title = "Angels of Death", AuthorId = 5, GenreId = 5, DateOfPublishing = new DateTime(2018, 05, 17) },
                new Book() { BookId = 6, Title = "Gleipnir", AuthorId = 6, GenreId = 6, DateOfPublishing = new DateTime(2017, 07, 17) });
        }
    }
}
