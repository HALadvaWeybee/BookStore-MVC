using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Dynamic;
using Web.BookStore.Models;
using Web.BookStore.Services;

namespace Web.BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfiguration;  
        private readonly IUserService _userService;

        public HomeController(IOptions<NewBookAlertConfig> newBookAlertConfiguration, IUserService userService)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
            _userService = userService;
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

            var userId = _userService.GetUserId();
            var isAuthenticated = _userService.IsAuthenticated();

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
        [Route("aboutus")]
        public ViewResult AboutUs()
        {
            Title = "About us";
            return View();
        }

        [Route("contactus")]
        public ViewResult ContactUs()
        {
            Title = "Contact us";
            return View();
        }
    }
}
