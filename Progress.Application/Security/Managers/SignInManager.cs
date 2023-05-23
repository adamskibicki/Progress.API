using Progress.Application.Security.Contracts;
using Progress.Application.Security.Models;

namespace Progress.Application.Security.Managers
{
    public class SignInManager : ISignInManager<User>
    {
        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            if (password == "12345")
            {
                return Task.FromResult(SignInResult.Success);
            }
            else
            {
                return Task.FromResult(SignInResult.Failed(new List<string> { "Password is wrong" }));
            }
        }
    }
}
