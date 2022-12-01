using Web.BookStore.Enums;

namespace Web.BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int LanguageId { get; set; } 
        //public LanguageEnum? LanguageEnum { get; set; }
        public int TotalPages { get; set; }
        
        public Languages Language { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
