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

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Rate(int id, int rating)
        {
            Console.WriteLine("----------------------------------");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new { success = false, message = "Пользователь не найден" });

            try
            {
                // Загружаем SQL-запрос из файла
                var sqlPath = Path.Combine(Directory.GetCurrentDirectory(),"SQL", "RateMovie.sql");
                var sql = await System.IO.File.ReadAllTextAsync(sqlPath);

                // Вставляем параметры в SQL-запрос
                var finalSql = string.Format(sql, userId, id, rating);

                // Выполняем SQL-запрос
                await _context.Database.ExecuteSqlRawAsync(finalSql);

                return Json(new { success = true, message = $"Оценка {rating}/10 сохранена" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ошибка при сохранении оценки", error = ex.Message });
            }
        }
    }
}