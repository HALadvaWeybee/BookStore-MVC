using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

namespace Web.BookStore.Helpers
{
    public class MyCutomValidation2Attribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                int pages = Convert.ToInt32(value);
                if(pages > 100)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Book page is must grated than 100");
        }
    }
}
