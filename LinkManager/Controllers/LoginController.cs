using LinkManager.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Veritabanı işlemleri için
using System.Security.Claims;

namespace LinkManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        // Veritabanını içeri alıyoruz (Dependency Injection)
        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("/account/login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            // 1. Veritabanından kullanıcıyı bul
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // 2. Bulduysan Kimlik Kartını Oluştur
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FullName), // Ekranda adı gözükecek
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // 3. Giriş Yap
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return LocalRedirect("/");
            }

            // Hatalıysa geri gönder
            return LocalRedirect("/login?error=true");
        }

        [HttpGet("/account/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}