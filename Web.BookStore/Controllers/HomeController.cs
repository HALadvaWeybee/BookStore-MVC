using Microsoft.AspNetCore.Mvc;

namespace Web.BookStore.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            return View();  
            //var obj = new { id = 1, name = "test" };
            //return View("AboutUS",obj);
            //return View("../../TempView/Himanshu");
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
