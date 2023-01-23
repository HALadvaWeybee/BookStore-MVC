using Web.BookStore.Models;

namespace Web.BookStore.Repositery
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}