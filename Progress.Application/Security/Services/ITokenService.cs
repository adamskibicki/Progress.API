using Progress.Application.Persistence.Entities;

namespace Progress.Application.Security.Services;

public interface ITokenService
{
    string CreateToken(User user);
}