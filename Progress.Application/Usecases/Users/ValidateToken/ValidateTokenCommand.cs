using System.Security.Claims;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Progress.Application.Common;
using Progress.Application.Persistence.Entities;
using Progress.Application.Usecases.Users.Login;

namespace Progress.Application.Usecases.Users.ValidateToken;

public record ValidateTokenCommand() : IRequest<Either<Failure, ValidateTokenResponseDto>>;

public class ValidateTokenCommandHandler : ValidationRequestHandler<ValidateTokenCommand, ValidateTokenResponseDto>
{
    private readonly UserManager<User> userManager;
    private readonly IHttpContextAccessor httpContextAccessor;

    public ValidateTokenCommandHandler(IEnumerable<IValidator<ValidateTokenCommand>> validators,
        UserManager<User> userManager, IHttpContextAccessor httpContextAccessor) : base(validators)
    {
        this.userManager = userManager;
        this.httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<Either<Failure, ValidateTokenResponseDto>> WrappedHandle(ValidateTokenCommand request,
        CancellationToken cancellationToken)
    {
        var userId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if(userId is null)
            return new Failure(new Exception("Token invalid"));
        
        var managedUser = await userManager.FindByIdAsync(userId);
        if (managedUser == null)
        {
            return new Failure(new Exception("Token invalid"));
        }

        return new ValidateTokenResponseDto(managedUser.Id, managedUser.UserName, managedUser.Email);
    }
}