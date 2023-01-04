using Progress.Application.Security.Contracts;
using Progress.Application.Security.Models;
using Progress.Infrastructure.Security.Models;

namespace Progress.Infrastructure.Security.Managers
{
    public class SignInManager : ISignInManager<User>
    {
        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            //TODO: add db implementation later
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
