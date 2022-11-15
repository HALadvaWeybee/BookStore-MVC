using Microsoft.AspNetCore.Mvc;

namespace Web.BookStore.Controllers
{
    public class HomeController: Controller
    {
        public string Index()
        {
            return "this is my application";
        }
    }
}
