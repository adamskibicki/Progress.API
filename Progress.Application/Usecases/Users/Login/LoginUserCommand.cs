using System.Text;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Progress.Application.Common;
using Progress.Application.Persistence.Entities;
using Progress.Application.Security.Services;

namespace Progress.Application.Usecases.Users.Login;

public record LoginUserCommand(
    string Email,
    string Password
) : IRequest<Either<Failure, LoginUserResponseDto>>;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}

public class LoginUserCommandHandler : ValidationRequestHandler<LoginUserCommand, LoginUserResponseDto>
{
    private readonly UserManager<User> userManager;
    private readonly ITokenService tokenService;

    public LoginUserCommandHandler(IEnumerable<IValidator<LoginUserCommand>> validators,
        UserManager<User> userManager, ITokenService tokenService) : base(validators)
    {
        this.userManager = userManager;
        this.tokenService = tokenService;
    }

    protected override async Task<Either<Failure, LoginUserResponseDto>> WrappedHandle(LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var managedUser = await userManager.FindByEmailAsync(request.Email);
        if (managedUser == null)
        {
            return new Failure(new Exception("Bad credentials"));
        }
        
        var isPasswordValid = await userManager.CheckPasswordAsync(managedUser, request.Password);
        if (!isPasswordValid)
        {
            return new Failure(new Exception("Bad credentials"));
        }
        
        var token = tokenService.CreateToken(managedUser);

        return new LoginUserResponseDto(managedUser.Id, managedUser.UserName, managedUser.Email, token);
    }
}