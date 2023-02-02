using System.ComponentModel.DataAnnotations;

namespace Web.BookStore.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm NewPassword")]
        [Compare("NewPassword", ErrorMessage = "Confirm new Password does not match")]
        public string ConfirmNewPassword { get; set;}
    }
}
