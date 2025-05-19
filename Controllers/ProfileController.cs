using FranchiseVerse.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FranchiseVerse.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // 1. Получаем ID текущего пользователя из токена
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized("User ID not found in token.");
            }

            uint userId;
            if (!uint.TryParse(userIdClaim, out userId))
            {
                return BadRequest("Invalid user ID format.");
            }

            // 2. Находим пользователя в базе данных
            var user = await _context.user.FindAsync(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // 3. Передаем данные пользователя в представление
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            try
            {
                // Получаем идентификатор пользователя из токена
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim) || !uint.TryParse(userIdClaim, out uint userId))
                {
                    return Unauthorized("User ID not found or invalid.");
                }

                // Вызов функции PostgreSQL через EF Core
                await _context.DeleteUserById(userId);

                return RedirectToAction("Logout", "Auth"); // Перенаправляем на страницу выхода
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка при удалении пользователя.");
                return View();
            }
        }
    }
}
