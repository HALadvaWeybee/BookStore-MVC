using Microsoft.AspNetCore.Identity;
using Web.BookStore.Models;
using Web.BookStore.Services;

namespace Web.BookStore.Repositery
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userSerive;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserService userSerive) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userSerive = userSerive;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpModel model)
        {
            var user = new ApplicationUser()
            {
                FirstName= model.FirstName,
                LastName= model.LastName,
                Email= model.Email,
                UserName = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel model)
        {
           var result =  await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userSerive.GetUserId();
            var user = await _userManager!.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }
}
