using Microsoft.AspNetCore.Mvc;
using Web.BookStore.Repositery;

namespace Web.BookStore.Controllers
{
    public class LanguageController : Controller
    {
        private readonly LanguageRepository _languageRepository;

        public LanguageController(LanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        
    }
}
