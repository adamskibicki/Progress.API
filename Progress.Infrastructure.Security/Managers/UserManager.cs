using Progress.Application.Security.Contracts;
using Progress.Application.Security.Models;
using Progress.Infrastructure.Security.Models;
using System.Security.Claims;

namespace Progress.Infrastructure.Security.Managers
{
    public class UserManager : IUserManager<User>
    {
        public Task<User> FindByEmailAsync(string email)
        {
            string tolower = email.ToLowerInvariant();
            var user = StaticUserList.Users().FirstOrDefault
                (p => p.Email.ToLowerInvariant() == tolower);

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            string tolower = userName.ToLowerInvariant();
            var user = StaticUserList.Users().FirstOrDefault
                (p => p.UserName.ToLowerInvariant() == tolower);

            return Task.FromResult(user);
        }

        public Task<List<Claim>> GetClaimsAsync(User user)
        {
            Claim c = new Claim("MyCos", "MyValue");
            var lis = new List<Claim>();
            lis.Add(c);
            return Task.FromResult(lis);
        }

        public Task<List<string>> GetRolesAsync(User user)
        {
            string c = "User";
            var lis = new List<string>();
            lis.Add(c);
            return Task.FromResult(lis);
        }

        public Task<UserManagerResult> CreateAsync(User user, string password)
        {
            StaticUserList.Users().Add(user);

            return Task.FromResult(UserManagerResult.Success);
        }
    }
}
