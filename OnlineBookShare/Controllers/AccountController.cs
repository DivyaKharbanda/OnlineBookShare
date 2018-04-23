using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShare.Models;
using OnlineBookShare.ViewModels;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookShare.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return View(user);
            if (_userRepository.IsValidUser(user))
            {
                HttpContext.Session.SetString("UserId", _userRepository.GetUserId(user.UserName).ToString());
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "User name/password not found");
            return View(user);
            
        }
    }
}
