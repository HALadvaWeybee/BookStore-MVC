using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.BookStore.Models;
using Web.BookStore.Repositery;

namespace Web.BookStore.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [ViewData]
        public string? Title { get; set; }

        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("~/all-books")]
        public async Task<IActionResult> GetAllBooks()
        {
            Title = "All Books";
            var data = await _bookRepository!.GetAllBooks();

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

        [Authorize]
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

            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "book/cover/";
                    bookModel.CoverImageURL = await UploadImage(folder, bookModel.CoverPhoto);
                }
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
            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }

    }
}

