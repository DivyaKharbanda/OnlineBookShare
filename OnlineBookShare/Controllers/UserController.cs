using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookShare.Models;
using OnlineBookShare.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookShare.Controllers
{
    public class UserController : Controller
    {
        private readonly IBookMasterRepository _bookMasterRepository;
        public UserController(IBookMasterRepository bookMasterRepository)
        {
            _bookMasterRepository = bookMasterRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var booksList = _bookMasterRepository.GetBooksByUserId(1);
            var booksViewModel = new BooksViewModel
            {
                Title = "Your Books",
                books = booksList
            };
            return View(booksViewModel);
        }
    }
}
