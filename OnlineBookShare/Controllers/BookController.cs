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
    public class BookController : Controller
    {
        private readonly IBookMasterRepository _bookMasterRepository;
        public BookController(IBookMasterRepository bookMasterRepository)
        {
            _bookMasterRepository = bookMasterRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var booksList = _bookMasterRepository.GetBooksByUserId(UserId);
            var booksViewModel = new BooksViewModel
            {
                Title = "Your Books",
                books = booksList
            };
            return View(booksViewModel);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(AddBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                int userId = Int32.Parse(HttpContext.Session.GetString("UserId"));
                BookMaster bookToAdd = new BookMaster
                {
                    Title = book.Title,
                    Author = book.Author,
                    ShortDescription = book.ShortDescription,
                    LongDescription = book.LongDescription,
                    UserId = userId
                };
                if (_bookMasterRepository.AddBook(bookToAdd) > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Operation unsuccessful. Please raise a ticket or try again!");
                return View(book);
            }
            return View(book);
        }

        public IActionResult DeleteBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteBook(int bookId)
        {
            BookMaster bookToDelete = _bookMasterRepository.GetBook(bookId);
            int deleteSuccessFlag = _bookMasterRepository.DeleteBook(bookToDelete);
            if (deleteSuccessFlag > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult UpdateBook()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult UpdateBook(int bookId)
        {
            BookMaster bookToUpdate = _bookMasterRepository.GetBook(bookId);
            int updateSuccessFlag = _bookMasterRepository.DeleteBook(bookToUpdate);
            if (updateSuccessFlag > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
