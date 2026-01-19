using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafeCamProject.Models;
using SafeCamProject.Services.Interfaces;
using SafeCamProject.ViewsModel.Account;

namespace SafeCamProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountService accountService, SignInManager<AppUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUIVM registerUIVM)
        {
            if (!ModelState.IsValid) { return View(registerUIVM); }
            var result = await _accountService.RegisterAsync(registerUIVM);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerUIVM);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUIVM loginUIVM)
        {
            if (!ModelState.IsValid) { return View(loginUIVM); }
            var result = await _accountService.LoginAsync(loginUIVM);
            if (!result.Succeeded)
            {

                ModelState.AddModelError("", "Invalid Login Attempt");

                return View(loginUIVM);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
