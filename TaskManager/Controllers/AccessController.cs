using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TaskManager.Models;

namespace TaskManager.Controllers
{
	public class AccessController : Controller
	{
		public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Login(VMLogin modelLogin)
		{ if (modelLogin.Email=="asmae@meryem.com" && modelLogin.Password == "123")
			{
				List<Claim> claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier , modelLogin.Email),
					new Claim("OtherPropreties" , "Example Role")
				};
				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				AuthenticationProperties properties = new AuthenticationProperties()
				{
					AllowRefresh = true,
					IsPersistent = modelLogin.keepLoggedIn
				};
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity), properties);
				return RedirectToAction("Index", "Home");
			}
			ViewData["ValidateMessage"] = "user not found";
			return View();
		}
	}
}
