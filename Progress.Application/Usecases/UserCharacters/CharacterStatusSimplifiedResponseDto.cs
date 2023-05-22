namespace Progress.Application.Usecases.UserCharacters
{
    public class CharacterStatusSimplifiedResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}