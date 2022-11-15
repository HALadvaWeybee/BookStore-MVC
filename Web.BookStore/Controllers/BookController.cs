using Microsoft.AspNetCore.Mvc;

namespace Web.BookStore.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "All Books";
        }
        public string GetBook(int id)
        {
            return "ladva book";
        }
        public string SearchBook(string BookName, string AuthorName)
        {
            return $"this book is = {BookName} and {AuthorName}";
        }
    }
}
