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
            var booksList = _bookMasterRepository.GetBooksByUserId(UserId).ToList();

            var booksViewModel = new BooksViewModel();
            if (booksList != null && booksList.Count() != 0)
            {
                booksViewModel.Title = "Your Books";
                booksViewModel.books = booksList;
                return View(booksViewModel);
            }
            else
            {
                booksViewModel.Title = "Your Books";
                booksViewModel.books = booksList;
                ModelState.AddModelError("", "You don't have any books in system. Please add a book.");
                return View(booksViewModel);
            }
            
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
                    return RedirectToAction("Index", "Book");
                }
                ModelState.AddModelError("", "Operation unsuccessful. Book already present in database.");
                return View(book);
            }
            return View(book);
        }

        public IActionResult DeleteBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteBook(DeleteBookViewModel bookModel)
        {
            BookMaster bookToDelete = _bookMasterRepository.GetBook(bookModel.BookId);
            int deleteSuccessFlag = _bookMasterRepository.DeleteBook(bookToDelete);
            if (deleteSuccessFlag > 0)
            {
                return RedirectToAction("Index", "Book");
            }
            ModelState.AddModelError("", "Operation unsuccessful. Book id is not correct.");
            return View(bookModel);
        }
        public IActionResult Update()
        {
            var updateBookView = new UpdateBookViewModel
            {
                InfoFetched = false,
                Title = "",
                Author = "",
                BookMasterId = 0,
                ShortDescription = "",
                LongDescription = ""
            };
            return View(updateBookView);
        }
        [HttpPost]
        public IActionResult Update(UpdateBookViewModel book)
        {
            BookMaster bookToUpdate = _bookMasterRepository.GetBook(book.BookMasterId);
            if(bookToUpdate != null)
            {
                var updateBookViewModel = new UpdateBookViewModel
                {
                    InfoFetched = true,
                    Title = bookToUpdate.Title,
                    Author = bookToUpdate.Author,
                    BookMasterId = bookToUpdate.BookMasterId,
                    ShortDescription = bookToUpdate.ShortDescription,
                    LongDescription = bookToUpdate.LongDescription
                };
                ModelState.AddModelError("", "Sorry!Feature not implemented yet.");
                return View(updateBookViewModel);
            }
            ModelState.AddModelError("", "Operation unsuccessful. Book id is not correct.");
            return View(book);
        }

        [HttpPost]
        public IActionResult UpdateBook(UpdateBookViewModel book)
        {
            BookMaster bookToUpdate = _bookMasterRepository.GetBook(book.BookMasterId);
            int updateSuccessFlag = _bookMasterRepository.DeleteBook(bookToUpdate);
            if (updateSuccessFlag > 0)
            {
                return RedirectToAction("Index", "Book");
            }
            ModelState.AddModelError("", "Operation not successfull");
            return RedirectToAction("Update", "Book");
        }
    }
}
