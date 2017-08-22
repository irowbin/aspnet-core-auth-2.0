using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var claims = new List<Claim>
                         {
                             new Claim( ClaimTypes.GivenName, "aspnet core", ClaimValueTypes.String)
                         };
            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("scheme1", principal);
            return View();
        }

        public IActionResult About()
        {
            var user = HttpContext.User;

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
