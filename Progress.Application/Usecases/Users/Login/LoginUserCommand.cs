using System.Text;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Progress.Application.Common;
using Progress.Application.Persistence;
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
    private readonly ApplicationDbContext dbContext;
    private readonly ITokenService tokenService;

    public LoginUserCommandHandler(IEnumerable<IValidator<LoginUserCommand>> validators,
        UserManager<User> userManager, ApplicationDbContext dbContext, ITokenService tokenService) : base(validators)
    {
        this.userManager = userManager;
        this.dbContext = dbContext;
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
        
        var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userInDb is null)
            return new Failure(new Exception("Unauthorized"));
        
        var token = tokenService.CreateToken(userInDb);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new LoginUserResponseDto(userInDb.UserName, userInDb.Email, token);
    }
}