using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SafeCamProject.Models;
using SafeCamProject.Services.Interfaces;
using SafeCamProject.ViewsModel.Account;

namespace SafeCamProject.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> LoginAsync(LoginUIVM loginUIVM)
        {
            var user = await _userManager.FindByNameAsync(loginUIVM.EmailOrUsername) ??
                await _userManager.FindByEmailAsync(loginUIVM.EmailOrUsername);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginUIVM.Password,false,false);
            return result;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterUIVM registerUIVM)
        {
            var user = new AppUser
            {
                Fullname = registerUIVM.Username,
                UserName = registerUIVM.Username,
                Email = registerUIVM.Email
            };

            var result = await _userManager.CreateAsync(user,registerUIVM.Password);
            return result;
        }
    }
}
