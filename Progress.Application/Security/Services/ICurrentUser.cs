namespace Progress.Application.Security.Services;

public interface ICurrentUser
{
    Guid Id { get; }
}