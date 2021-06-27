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
    public class AuthorController : Controller
    {
        private readonly IRepo _irepo;
        private readonly ApplicationDbContext _db;

        public AuthorController(IRepo irepo, ApplicationDbContext db)
        {
            _irepo = irepo;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
             //IList<Book> authorList = _db.books.Include(g => g.Title).ToList();

            var authorList = await _irepo.SelectAll<Author>();
            return View(authorList);
        }

        [HttpGet]
        public async Task<IActionResult> CreatAuthor()
        {
           // ViewBag.genresId = new SelectList(await _irepo.SelectAll<Book>(), "BookId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatAuthor(Author author)
        {
            var newAuthorObj = new Genre() { Name = author.AuthorName };
            await _irepo.CreatAsync<Genre>(newAuthorObj);

            return RedirectToAction(nameof(Index));
        }
    }
}
