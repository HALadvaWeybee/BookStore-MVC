using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Web.BookStore.Models;
using Web.BookStore.Repositery;

namespace Web.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        [ViewData]
        public string? Title { get; set; }

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ViewResult GetAllBooks()
        {
            Title = "All Books";
            var data = _bookRepository?.GetAllBooks();
            return View(data);
        }

        [Route("book-detail/{id}", Name = "BookDetailRoute")]
        public ViewResult GetBook(int id)
        {
            dynamic data = new ExpandoObject();
            data.book = _bookRepository.GetBookByID(id);
            data.ownerName = "himanshu ladva";
            Title = "Book Detail " + data.book?.Title;
            return View(data);
        }
        public ViewResult SearchBook(string BookName, string AuthorName)
        {
            var data = _bookRepository?.SearchBook(BookName, AuthorName);
            return View();
        }

        public ViewResult AddBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookModel bookModel)
        {
            int id= _bookRepository.AddBookInDataBase(bookModel);

            if(id > 0)
            {
                return RedirectToAction("AddBook", new { isSuccess = true, bookId = id});
            }
            return View();
        }
    }
}

