namespace Progress.Application.Usecases.Users.Login;

public record LoginUserResponseDto(Guid Id, string UserName, string Email, string Token);