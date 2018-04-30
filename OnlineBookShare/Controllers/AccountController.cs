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
        private readonly IUserDetailsRepository _userDetailsRepository;
        public AccountController(IUserRepository userRepository, IUserDetailsRepository userDetailsRepository)
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
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
                return RedirectToAction("Index", "Book");
            }
            ModelState.AddModelError("", "User name/password not found");
            return View(user);
            
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginViewModel User)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = User.UserName,
                    Password = User.Password
                };
                if(_userRepository.AddUser(user) > 0)
                {
                    HttpContext.Session.SetString("UserId", _userRepository.GetUserId(user.UserName).ToString());
                    return RedirectToAction("Index", "Book");
                }
                ModelState.AddModelError("", "Operation unsuccessful. Please raise a ticket or try again!");
                return View(User);
            }
            return View(User);
        }

        public IActionResult AddUserDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUserDetails(AddUserDeatilsViewModel UserDetailsViewModel)
        {
            if(ModelState.IsValid)
            {
                int userId = Int32 .Parse(HttpContext.Session.GetString("UserId"));
                User User = _userRepository.GetUser(userId);
                UserDetails userDetails = new UserDetails
                {
                    UserId = userId,
                    Email = UserDetailsViewModel.Email,
                    Address = UserDetailsViewModel.Address,
                    ContactNumber = UserDetailsViewModel.ContactNumber
                };
                if(_userDetailsRepository.AddUserDetails(userDetails) > 0)
                {
                    return RedirectToAction("Index", "Book");
                }
                ModelState.AddModelError("", "Operation unsuccessful. Please raise a ticket or try again!");
                return View(UserDetailsViewModel);
            }
            return View(UserDetailsViewModel);
        }
        public IActionResult UserDetails()
        {
            
            int UserId = Convert.ToInt32( HttpContext.Session.GetString("UserId"));
            User User = _userRepository.GetUser(UserId);
            UserDetails UserDetails = _userDetailsRepository.GetUserDetails(UserId);
            if(!(UserDetails == null))
            {
                UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel
                {
                    UserId = User.UserId,
                    UserName = User.UserName,
                    ContactNumber = UserDetails.ContactNumber,
                    Address = UserDetails.Address,
                    Email = UserDetails.Email
                };
                return View(userDetailsViewModel);
            }
            return RedirectToAction("AddUserDetails", "Account");
        }
        public IActionResult updateUserDetails()
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            UpdateUserViewModel user = new UpdateUserViewModel();
            
            UserDetails userDetailsToRender = _userDetailsRepository.GetUserDetails(UserId);
            if(userDetailsToRender != null)
            {
                user.UserId = UserId;
                user.ContactNumber = userDetailsToRender.ContactNumber;
                user.Address = userDetailsToRender.Address;
                user.Email = userDetailsToRender.Email;
            }
            if(user.Address != null)
            {
                return View(user);
            }
            else
            {
                ModelState.AddModelError("", "Please add details first.");
                return View(user);
            }
            
        }

        [HttpPost]
        public IActionResult updateUserDetails(UpdateUserViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {

                _userDetailsRepository.updateAddressByUserId(UserViewModel.UserId,UserViewModel.Address);
                _userDetailsRepository.updateContactByUserId(UserViewModel.UserId, UserViewModel.ContactNumber);
                _userDetailsRepository.updateEmailByUserId(UserViewModel.UserId, UserViewModel.Email);
                return RedirectToAction("Index","Book");
                
            }
            ModelState.AddModelError("", "Please see the admin.");
            return View(UserViewModel);
        }

        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
