using Microsoft.AspNetCore.Mvc;
using Web.BookStore.Models;
using Web.BookStore.Repositery;

namespace Web.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository? _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data =  _bookRepository.GetAllBooks();
            return View();
        }
        public ViewResult GetBook(int id)
        {
            var data =  _bookRepository.GetBookByID(id);
            return View();
        }
        public ViewResult SearchBook(string BookName, string AuthorName)
        {
            var data =  _bookRepository.SearchBook(BookName, AuthorName);
            return View();
        }
    }
}
