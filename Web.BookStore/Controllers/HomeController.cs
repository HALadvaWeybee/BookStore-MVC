using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Dynamic;
using Web.BookStore.Models;

namespace Web.BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfiguration;

        public HomeController(IOptions<NewBookAlertConfig> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
        }
        [ViewData]
        public string? CustomName { get; set; }
        [ViewData]
        public string? Title { get; set; }
        [ViewData]
        public BookModel? Book { get; set; }

        [Route("")]
        public ViewResult Index()
        {
            //var result = _configuration["AppName"];
            /*var newBook = _configuration.GetSection("NewBookAlert");
            var result2 = newBook.GetValue<bool>("DisplayNewBookAlert");
            var result3 = newBook.GetValue<string>("BookName");*/
            /*var newBook = new NewBookAlertConfig();
            _configuration.Bind("NewBookAlert", newBook);*/

            bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;

            //view data attribute
            CustomName = "by himanshu ladva";
            Title = "Home Ladva";
            Book = new BookModel() { Id = 10, Author = "pablo" };

            // viewdata
            ViewData["name"] = "Himanshu Ladva";
            ViewData["properties"] = new BookModel() { Id = 1, Title = "ladva book" };

            // view bag
            // ViewBag.Title = "National Library"; 

            dynamic data = new ExpandoObject();
            data.id = 1;
            data.name = "himanshu";
            ViewBag.Data = data;
            ViewBag.Type = new BookModel() { Id = 1, Title = "Ladva book" };
            return View();

            //var obj = new { id = 1, name = "test" };
            //return View("AboutUS",obj);
            //return View("../../TempView/Himanshu");
        }

        //[Route("{id:int:min(1)}")]
        public ViewResult AboutUs(int id)
        {
            Title = "About us";
            return View();
        }
        public ViewResult ContactUs()
        {
            Title = "Contact us";
            return View();
        }
    }
}
