using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Progress.Application.Security.Services;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor httpContextAccessor;
    
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid Id
    {
        get
        {
            var value = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            
            return value is null ? Guid.Empty : Guid.Parse(value);
        }
    }
}