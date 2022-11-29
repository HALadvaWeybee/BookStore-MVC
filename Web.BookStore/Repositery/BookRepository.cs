using Web.BookStore.Data;
using Web.BookStore.Models;

namespace Web.BookStore.Repositery
{
    public class BookRepository
    {
        private readonly BookStoreContext _bookStoreContext;

        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public int AddBookInDataBase(BookModel model)
        {
            var newBook = new Books()
            {
                CreatedOn = DateTime.UtcNow,
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow,
            };
            _bookStoreContext.Books.Add(newBook);    
            _bookStoreContext.SaveChanges();
            return newBook.Id;
           
        }
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
                new BookModel() { Id = 1,Title = "MVC", Author = "Ram", Description = "This is Description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 2, Title = "PHY", Author = "lashman", Description = "This is Description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 3, Title = "COM", Author = "bharat", Description = "This is Description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 4, Title = "FREM", Author = "shratugan", Description = "This is Description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 5, Title = "ASD", Author = "janki", Description = "This is description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 6, Title = "CDF", Author = "kausalya", Description = "This is description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 7, Title = "YUI", Author = "sakuni", Description = "This is description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 8, Title = "WER", Author = "kansh", Description = "This is description of book", Category ="Social", Language="English", TotalPages = 101},
                new BookModel() { Id = 9, Title = "QAZ", Author = "ravan", Description = "This is description of book", Category ="Social", Language="English", TotalPages = 101},
            };
        }
    }
}
