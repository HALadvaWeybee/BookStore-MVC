using Microsoft.AspNetCore.Identity;
using Web.BookStore.Models;

namespace Web.BookStore.Repositery
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpModel model);
        Task<SignInResult> PasswordSignInAsync(SignInModel model);
        Task SignOutAsync();
    }
}