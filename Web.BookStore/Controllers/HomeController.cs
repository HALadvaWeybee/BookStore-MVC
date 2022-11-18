using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Web.BookStore.Models;

namespace Web.BookStore.Controllers
{
    public class HomeController: Controller
    {
        [ViewData]
        public string CustomName {get; set;}
        [ViewData]
        public string Title {get; set;}
        [ViewData]
        public BookModel Book { get; set;}
        public ViewResult Index()
        {
            //view data attribute
            CustomName = "by himanshu ladva";
            Title = "Home Ladva";
            Book = new BookModel() {Id = 10, Author = "pablo"};

            // viewdata
            ViewData["name"] = "Himanshu Ladva";
            ViewData["properties"] = new BookModel(){ Id = 1, Title = "ladva book"};
            // view bag
            // ViewBag.Title = "National Library";
            dynamic data = new ExpandoObject();
            data.id = 1;
            data.name = "himanshu";
            ViewBag.Data = data;
            ViewBag.Type = new BookModel(){Id = 1, Title = "Ladva book"};
            return View();
            //var obj = new { id = 1, name = "test" };
            //return View("AboutUS",obj);
            //return View("../../TempView/Himanshu");
        }
        public ViewResult AboutUs()
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
