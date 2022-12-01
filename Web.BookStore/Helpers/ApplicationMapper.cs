using AutoMapper;
using Web.BookStore.Data;
using Web.BookStore.Models;

namespace Web.BookStore.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
            CreateMap<Languages, LanguageModel>().ReverseMap();
        }
    }
}
