using System.Threading.Tasks;
using CommentApp.Domain.Entities;
using CommentApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var isValid = await _accountService.ValidateCredentialsAsync(username, password);
            if (isValid)
            {
                return RedirectToAction("Index", "Post");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
    }
}
