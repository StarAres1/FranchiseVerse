using Microsoft.AspNetCore.Mvc;
using FranchiseVerse.Data;
using FranchiseVerse.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

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

        // GET: /Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.movie
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            int? userRating = null;

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId) && uint.TryParse(userId, out var uId))
                {
                    userRating = await _context.rate
                        .Where(r => r.MovieId == id && r.UserId == uId)
                        .Select(r => r.Rating)
                        .FirstOrDefaultAsync();
                }
            }

            ViewBag.UserRating = userRating;

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Rate(int id, int rating)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !uint.TryParse(userIdClaim, out var userId))
            {
                return RedirectToAction("Details", new { id });
            }

            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
                    $"SELECT rate_movie({userId}, {id}, {rating})"
                );
            }
            catch (Exception ex)
            {
                // Логируй ошибку при необходимости
                Console.WriteLine("Ошибка при сохранении оценки: " + ex.Message);
            }

            return RedirectToAction("Details", new { id });
        }
    }
}