using LibraryMVC_Demo.Data;
using LibraryMVC_Demo.Interfaces;
using LibraryMVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepo _irepo;
        private readonly ApplicationDbContext _db;

        public BookController(IRepo irepo, ApplicationDbContext db)
        {
            _irepo = irepo;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IList<Book> gebreList = _db.books.Include(g => g.Genre).ToList();
            IList<Book> authorList = _db.books.Include(g => g.Author).ToList();

            var bookList = await _irepo.SelectAll<Book>();
            return View(bookList);
        }

        [HttpGet]
        public async Task<IActionResult> CreatBook()
        {
             ViewBag.genresId = new SelectList(await _irepo.SelectAll<Genre>(), "GenreId", "Name");
            // ViewBag.authorsId = new SelectList((System.Collections.IEnumerable)_irepo.SelectAll<Genre>(), "AuthorId", "AuthorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatBook(Book book)
        {
            var newBookObj = new Book() { Title = book.Title, Author= book.Author, Genre = book.Genre };
            await _irepo.CreatAsync<Book>(newBookObj);

            return RedirectToAction(nameof(Index));
        }
    }
}
