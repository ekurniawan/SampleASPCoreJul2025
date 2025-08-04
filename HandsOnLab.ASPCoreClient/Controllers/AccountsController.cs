using HandsOnLab.ASPCoreClient.Models;
using HandsOnLab.ASPCoreClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.ASPCoreClient.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccount _account;
        public AccountsController(IAccount account)
        {
            _account = account;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _account.Login(loginViewModel);
                if (user != null)
                {
                    var account = new UserViewModel
                    {
                        Email = user.Email,
                        Token = user.Token
                    };

                    //convert to json system.text
                    var json = System.Text.Json.JsonSerializer.Serialize(account);

                    // Store user information in session or cookie
                    HttpContext.Session.SetString("account", json);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(loginViewModel);

        }

        public IActionResult Logout()
        {
            // Clear session or cookie
            HttpContext.Session.Remove("account");
            return RedirectToAction("Index", "Home");
        }
    }
}
