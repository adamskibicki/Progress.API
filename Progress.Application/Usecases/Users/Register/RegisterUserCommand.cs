using System.Text;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Progress.Application.Common;
using Progress.Application.Persistence.Entities;
using Unit = MediatR.Unit;

namespace Progress.Application.Usecases.Users.Register;

public record RegisterUserCommand(
    string Email,
    string UserName,
    string Password
) : IRequest<Either<Failure, Unit>>;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}

public class RegisterUserCommandHandler : ValidationRequestHandler<RegisterUserCommand, Unit>
{
    private readonly UserManager<User> userManager;

    public RegisterUserCommandHandler(IEnumerable<IValidator<RegisterUserCommand>> validators,
        UserManager<User> userManager) : base(validators)
    {
        this.userManager = userManager;
    }

    protected override async Task<Either<Failure, Unit>> WrappedHandle(RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = await userManager.CreateAsync(
            new User { UserName = request.UserName, Email = request.Email },
            request.Password
        );

        if (result.Succeeded)
        {
            return new Unit();
        }

        return new Failure(new Exception(BuildErrorMessage(result)));
    }

    private static string BuildErrorMessage(IdentityResult result)
    {
        var errorMessageBuilder = new StringBuilder();
        foreach (var error in result.Errors)
        {
            errorMessageBuilder.Append($"{error.Code}: {error.Description}");
            errorMessageBuilder.Append(Environment.NewLine);
        }

        return errorMessageBuilder.ToString();
    }
}