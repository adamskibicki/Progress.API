namespace Progress.Application.Usecases.Users.Login;

public record LoginUserResponseDto(string UserName, string Email, string Token);