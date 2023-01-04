using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Progress.Application.Security.Contracts;
using Progress.Application.Security.Models;
using Progress.Infrastructure.Security.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Progress.Infrastructure.Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserManager<User> userManager;
        private readonly JSONWebTokensSettings jwtSettings;

        public AuthenticationService(IUserManager<User> userManager, IOptions<JSONWebTokensSettings> jwtSettings)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Enail);

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            return new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
            };
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUser = await userManager.FindByNameAsync(request.UserName);

            if (existingUser is not null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var existingEmail = await userManager.FindByEmailAsync(request.Email);

            if (existingEmail is not null)
            {
                throw new Exception($"Email {request.Email} already exists.");
            }

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return new RegistrationResponse { UserId = user.Id };
            }
            else
            {
                throw new Exception($"{result.Errors}");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id.ToString()),
                new Claim(ClaimTypes.Role, "admin")
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }
    }
}
