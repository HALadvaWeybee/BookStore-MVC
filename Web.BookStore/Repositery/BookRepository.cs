using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web.BookStore.Data;
using Web.BookStore.Models;

namespace Web.BookStore.Repositery
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreContext bookStoreContext, IMapper mapper, IConfiguration configuration)
        {
            _bookStoreContext = bookStoreContext;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<int> AddBookInDataBase(BookModel model)
        {
            /*var newBook = new Books()
            {
                CreatedOn = DateTime.UtcNow,
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow,
            };*/
            var newBook = _mapper.Map<Books>(model);
            newBook.CreatedOn = DateTime.UtcNow;
            newBook.UpdatedOn = DateTime.UtcNow;
            await _bookStoreContext.Books.AddAsync(newBook);
            await _bookStoreContext.SaveChangesAsync();
            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            /*var result = await _bookStoreContext.Books.ToListAsync();
            var books = new List<BookModel>();
            if (result.Any() == true)
            {
                foreach (var item in result)
                {
                    books.Add(new BookModel()
                    {
                        Id = item.Id,
                        Author = item?.Author,
                        Description = item?.Description,
                        TotalPages = item.TotalPages,
                        Language = item?.Language,
                        Title = item?.Title,
                        Category = item?.Category
                    });
                }
            }*/
            return _mapper.Map<List<BookModel>>(await _bookStoreContext.Books.ToListAsync());
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return _mapper.Map<List<BookModel>>(await _bookStoreContext.Books.Take(count).ToListAsync());
        }
        public async Task<BookModel> GetBookByID(int id)
        {
            var book = await _bookStoreContext.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public string GetApplicaitonName()
        {
            return "Book Store App";
        }
        /*public List<BookModel> SearchBook(string title, string author)
         {
             return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList(); 
         }*/

    }
}
