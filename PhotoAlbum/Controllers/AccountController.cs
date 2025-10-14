using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PhotoAlbum.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {

            return View();
        }

        // POST: /Account/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {

            // Validate username and password (username and password stored in secrets.json)
            if (username == _configuration["username"] && password == _configuration["password"])
            {
                // Create a list of claims identifying the user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "admin"), // unique ID
                    new Claim(ClaimTypes.Name, "Administrator"), // human readable name
                    //new Claim(ClaimTypes.Role, "Smuggler"), // could use roles if needed         
                };

                // Create the identity from the claims
                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign-in the user with the cookie authentication scheme
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                                
                // TO-DO: fix bug where returnUrl is null!!!!!!!!

                if (!string.IsNullOrEmpty(returnUrl)) 
                {
                    // If user came from other page, re-direct back to that URL
                    return Redirect(returnUrl);    
                }
                else
                {
                    // Re-direct to home page
                    return RedirectToAction("Index", "Home");
                }

            }

            ViewBag.ErrorMessage = "Invalid username or password.";

            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            return View();
        }

        // POST: /Account/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutConfirmed()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Re-direct user to login page after logout
            return RedirectToAction("Login","Account");
        }
    }
}
