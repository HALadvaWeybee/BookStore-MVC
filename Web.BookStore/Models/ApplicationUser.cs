using Microsoft.AspNetCore.Identity;

namespace Web.BookStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? dateOfBirth {get; set;}
    }
}
