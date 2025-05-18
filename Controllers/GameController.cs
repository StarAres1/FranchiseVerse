using Microsoft.AspNetCore.Mvc;
using FranchiseVerse.Data;
using FranchiseVerse.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FranchiseVerse.Controllers
{
    public class GameController : Controller
    {
        private readonly AppDbContext _context;

        public GameController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;

            var query = _context.game.AsQueryable();

            /*
             * Здесь потом будут фильтры
             */

            int totalRecords = query.Count();

            var games = query
                .OrderByDescending(r => r.Rating)
                .Skip((page - 1) * pageSize) 
                .Take(pageSize)  
                .ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);


            return View(games);

        }
        
        [HttpGet]
        public IActionResult GamePage(int id)
        {
            var game = _context.game
                .Include(g => g.CharacterPersons)
                .ThenInclude(cp => cp.Character)
                .Include(g => g.CharacterPersons)
                .ThenInclude(cp => cp.Person)
                .Include(g => g.GamePersons)
                .ThenInclude(gp => gp.Person)
                .FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }
    }
}