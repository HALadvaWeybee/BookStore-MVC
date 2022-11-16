using Web.BookStore.Models;

namespace Web.BookStore.Repositery
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookByID(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList(); 
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1,Title = "MVC", Author = "Ram"},
                new BookModel() { Id = 2, Title = "PHY", Author = "lashman"},
                new BookModel() { Id = 3, Title = "COM", Author = "bharat"},
                new BookModel() { Id = 4, Title = "FREM", Author = "shratugan"},
                new BookModel() { Id = 5, Title = "CHE", Author = "janki"},
            };
        }
    }
}
