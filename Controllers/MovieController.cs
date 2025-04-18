using Microsoft.AspNetCore.Mvc;
using FranchiseVerse.Data;
using FranchiseVerse.Models;
using System.Threading.Tasks;

namespace FranchiseVerse.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;

            var query = _context.movie.AsQueryable();

            /*
             * Здесь потом будут фильтры
             */

            int totalRecords = query.Count();

            var movies = query
                .OrderByDescending(r => r.Rating)
                .Skip((page - 1) * pageSize) 
                .Take(pageSize)  
                .ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);


            return View(movies);

        }
    }
}