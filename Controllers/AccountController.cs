using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Web_KhoaHoc.Models;
using Web_KhoaHoc.Service;

namespace Web_KhoaHoc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
           
            if (account == null)
            {
                return View("Error");
            }
            if(! await new AuthService().Login(account.username??account.email, account.password))
            {
                ModelState.AddModelError(string.Empty, "Sai tên đăng nhập hoặc mật khẩu");
                return View(account);
            }
            Session.Session.currentAccount = account;
            TempData["Success"] = "Đăng nhập thành công!";
            return RedirectToAction("Main", "Home");
        }
      
        
    }
}
