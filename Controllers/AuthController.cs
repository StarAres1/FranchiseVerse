using FranchiseVerse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FranchiseVerse.Data;
using FranchiseVerse.Models;

namespace FranchiseVerse.Controllers
{

    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;

        public AuthController(AppDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            if (await _context.user.AnyAsync(u => u.UserName == model.UserName))
                return BadRequest("Username already exists.");

            if (await _context.user.AnyAsync(u => u.Email == model.Email))
                return BadRequest("Email already exists.");

            var hashedPassword = _authService.HashPassword(model.Password);

            var user = new User
            {
                UserName = model.UserName,
                Name = model.Name,
                Surename = model.Surename,
                Email = model.Email,
                PasswordHash = hashedPassword
            };

            _context.user.Add(user);
            await _context.SaveChangesAsync();

            // Перенаправляем пользователя на главную страницу
            return RedirectToAction("Index", "Home"); // метод , название контроллера
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(); // Возвращает представление Register.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDto model)
        {
            var user = await _context.user.FirstOrDefaultAsync(u => u.UserName == model.UserName);
            if (user == null || !_authService.VerifyPassword(model.Password, user.PasswordHash))
                return Unauthorized("Invalid username or password.");

            var token = _authService.GenerateJwtToken(user);
            // Сохраняем токен в куки
            Response.Cookies.Append("jwtToken", token, new CookieOptions
            {
                HttpOnly = true, // Защита от доступа через JavaScript
                Secure = true,   // Токен передается только по HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1) // Время действия токена
            });

            // Перенаправляем на главную страницу
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View(); // Возвращает представление Login.cshtml
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Удаляем куки или токен сессии, если они используются
            Response.Cookies.Delete("jwtToken");

            // Перенаправляем пользователя на главную страницу
            return RedirectToAction("Index", "Home"); // метод , название контроллера
        }
    }

}
