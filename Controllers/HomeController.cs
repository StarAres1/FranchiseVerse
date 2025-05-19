using System.Diagnostics;
using FranchiseVerse.Models;
using Microsoft.AspNetCore.Mvc;
using FranchiseVerse.Data;

namespace FranchiseVerse.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var randomGames = _context.RandomGames.AsEnumerable();
            var randomMovies = _context.RandomMovies.AsEnumerable();

            // Передаем оба списка в представление через кортеж
            return View((randomGames, randomMovies));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
