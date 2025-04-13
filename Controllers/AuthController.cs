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

            var user = new User
            {
                UserName = model.UserName,
                Name = model.Name,
                Surename = model.Surename,
                Email = model.Email,
                PasswordHash = model.Password
            };

            _context.user.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully." });
        }

        [HttpGet("Auth/Register")]
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
            return Ok(new { Token = token });
        }

        public IActionResult Login()
        {
            return View(); // Возвращает представление Login.cshtml
        }
    }

}
