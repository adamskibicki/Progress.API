using Progress.Application.Security.Models;
using System.Security.Claims;

namespace Progress.Application.Security.Contracts
{
    public interface IUserManager<TUser> where TUser : class
    {
        Task<List<string>> GetRolesAsync(TUser user);
        Task<List<Claim>> GetClaimsAsync(TUser user);
        Task<TUser> FindByEmailAsync(string email);
        Task<TUser> FindByNameAsync(string name);
        Task<UserManagerResult> CreateAsync(TUser user, string password);
    }
}
