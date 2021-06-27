using LibraryMVC_Demo.Data;
using LibraryMVC_Demo.Interfaces;
using LibraryMVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Controllers
{
    public class GenreController : Controller
    {
        private readonly IRepo _irepo;
        private readonly ApplicationDbContext _db;

        public GenreController(IRepo irepo, ApplicationDbContext db)
        {
            _irepo = irepo;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // IList<Genre> genreObj = _db.genres.Include(g => g.Name).ToList();

            var genreObj = await _irepo.SelectAll<Genre>();
            return View(genreObj);
        }

        [HttpGet]
        public async Task<IActionResult> CreateGenre()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGenre(Genre genre)
        {
            var newGenreObj = new Genre() { Name = genre.Name };
            await _irepo.CreatAsync<Genre>(newGenreObj);

            return RedirectToAction(nameof(Index));
        }
    }
}
