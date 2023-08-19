using BankingEx.Models;
using BankingEx.PeristanceLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



namespace BankingEx.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ShowError = false;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            Employee loggedInUser = EmployeeContext.Login(userName, password);
            if (loggedInUser != null)
            {
                List<Claim> clamins = new List<Claim>();
                clamins.Add(new Claim(ClaimTypes.Name, loggedInUser.Name)); // key value
                clamins.Add(new Claim(ClaimTypes.Name, loggedInUser.Id.ToString()));
                if(loggedInUser.Username == "admin")
                {
                    clamins.Add(new Claim(ClaimTypes.Role, "Account"));
                }
                else
                {
                    clamins.Add(new Claim(ClaimTypes.Role, "Customer"));
                }


                ClaimsIdentity identity = new ClaimsIdentity(clamins, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                AuthenticationProperties authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ViewBag.ShowError = true;
                ViewBag.Username = userName;
                return View();
            }




        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }
    }
}