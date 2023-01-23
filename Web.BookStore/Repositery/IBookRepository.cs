using Web.BookStore.Models;

namespace Web.BookStore.Repositery
{
    public interface IBookRepository
    {
        Task<int> AddBookInDataBase(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookByID(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);

        string GetApplicaitonName();
    }
}