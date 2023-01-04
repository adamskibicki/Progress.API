using Progress.Application.Security.Models;

namespace Progress.Application.Security.Contracts
{
    public interface ISignInManager<TUser> where TUser : class
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    }
}
