using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TaskManager.Models;
using TPEF.Data;
using System.Linq;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace TaskManager.Controllers
{
	public class AccessController : Controller
	{
        private readonly ApplicationDBContext _db;
		public int iduser;
        public AccessController(ApplicationDBContext db)
        {
			_db = db;
        }


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
        {
			var loginlist = _db.logins.ToList();
			var exist = false;
            foreach (var item in loginlist)
            {
				if (item.Email == modelLogin.Email && item.Password == modelLogin.Password)
				{	exist = true;
					iduser = item.Id;
				}
            }
            if (exist == true)
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
                TempData["UserId"] = iduser;
                return RedirectToAction("Index", "Home");
			}
			ViewData["ValidateMessage"] = "user not found";
			return View();
		}
	}
}
