using System.ComponentModel.DataAnnotations;
using Web.BookStore.Enums;
using Web.BookStore.Helpers;

namespace Web.BookStore.Models
{
    public class BookModel
    {
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "Enter Email Address")]
        //[EmailAddress]
        //public string MyField { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required..")]
        [StringLength(10, MinimumLength = 5)]
        //[MyCustomValidation("azure")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Author is Required..")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string? Category { get; set; }

        [Required(ErrorMessage = "Please chosse language")]
        [Display(Name = "Choose a language")]
        public int LanguageId { get; set; }

        // for one image
        [Display(Name = "upload photo")]
        [Required]
        public IFormFile ?CoverPhoto { get; set; }

        public string? CoverImageURL { get; set; }

        //[Required(ErrorMessage = "TotalPages is Required..")]
        //[Display(Name = "Total pages of book")]
        [MyCutomValidation2]
        public int? TotalPages { get; set; }
    }
}
