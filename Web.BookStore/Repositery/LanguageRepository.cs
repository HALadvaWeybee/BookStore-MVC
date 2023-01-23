using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web.BookStore.Data;
using Web.BookStore.Models;

namespace Web.BookStore.Repositery
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IMapper _mapper;

        public LanguageRepository(BookStoreContext bookStoreContext, IMapper mapper)
        {
            _bookStoreContext = bookStoreContext;
            _mapper = mapper;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            var result = await _bookStoreContext.Languages.ToListAsync();
            return _mapper.Map<List<LanguageModel>>(result);
        }
    }
}
