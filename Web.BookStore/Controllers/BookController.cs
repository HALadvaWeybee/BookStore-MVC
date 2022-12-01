using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.BookStore.Models;
using Web.BookStore.Repositery;

namespace Web.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly LanguageRepository _languageRepository;

        [ViewData]
        public string? Title { get; set; }

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<IActionResult> GetAllBooks()
        {
            Title = "All Books";
            var data = await _bookRepository?.GetAllBooks();

            return View(data);
        }

        [Route("book-detail/{id}", Name = "BookDetailRoute")]
        public async Task<IActionResult> GetBook(int id)
        {
            dynamic data = new ExpandoObject();
            data.book = await _bookRepository.GetBookByID(id);
            data.ownerName = data.book?.Title;
            Title = "Book Detail " + data.book?.Title;

            return View(data);
        }
        /* public ViewResult SearchBook(string BookName, string AuthorName)
         {
             var data = _bookRepository?.SearchBook(BookName, AuthorName);
             return View();
         }*/

        public async Task<IActionResult> AddBook(bool isSuccess = false, int bookId = 0)
        {
            /*ViewBag.Language = GetLanguages().Select(x => new SelectListItem()
            {
                Text = x.Text,
                Value = x.Id.ToString(),

            }).ToList();*/


            /*ViewBag.Language = new List<SelectListItem>() { 
               new SelectListItem() { Text = "Hindi", Value = "Hindi"},
               new SelectListItem() { Text = "English", Value = "English"},
               new SelectListItem() { Text = "Gujarati", Value = "Gujarati" ,Selected = true},
               new SelectListItem() { Text = "German", Value = "German"},
               new SelectListItem() { Text = "Urdu", Value = "Urdu"},
               new SelectListItem() { Text = "Chinese", Value = "Chinese"},
            };*/

            ViewBag.Languages =new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddBookInDataBase(bookModel);

                if (id > 0)
                {
                    return RedirectToAction("AddBook", new { isSuccess = true, bookId = id });
                }
            }
            /*ViewBag.Language = new List<SelectListItem>() { 
              new SelectListItem() { Text = "Hindi", Value = "Hindi"},
              new SelectListItem() { Text = "English", Value = "English"},
              new SelectListItem() { Text = "Gujarati", Value = "Gujarati" ,Selected = true},
              new SelectListItem() { Text = "German", Value = "German"},
              new SelectListItem() { Text = "Urdu", Value = "Urdu"},
              new SelectListItem() { Text = "Chinese", Value = "Chinese"},
           };*/
            ViewBag.Languages =new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }

        
    }
}

