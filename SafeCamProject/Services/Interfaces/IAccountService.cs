using Microsoft.AspNetCore.Identity;
using SafeCamProject.ViewsModel.Account;

namespace SafeCamProject.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterUIVM registerUIVM);
        Task<SignInResult> LoginAsync(LoginUIVM loginUIVM);
    }
}
