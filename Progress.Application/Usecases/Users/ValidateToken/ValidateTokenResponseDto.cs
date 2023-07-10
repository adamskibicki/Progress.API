namespace Progress.Application.Usecases.Users.ValidateToken;

public record ValidateTokenResponseDto(Guid Id, string UserName, string Email);