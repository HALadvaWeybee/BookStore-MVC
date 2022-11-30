using System.ComponentModel.DataAnnotations;
using Web.BookStore.Enums;

namespace Web.BookStore.Models
{
    public class BookModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter Email Address")]
        [EmailAddress]
        public string MyField { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required..")]
        [StringLength(10, MinimumLength = 5)]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Author is Required..")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string? Category { get; set; }

        //[Required(ErrorMessage = "Please chosse language")]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Please choose multilanguage")]
        [Display(Name = "Choose a language")]
        public LanguageEnum LanguageEnum { get; set; }

        [Required(ErrorMessage = "TotalPages is Required..")]
        [Display(Name = "Total pages of book")]
        public int? TotalPages { get; set; }
    }
}
