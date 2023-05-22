namespace Progress.Application.Usecases.UserCharacters
{
    public class UserCharacterResponseDto
    {
        public Guid Id { get; set; }
        public IEnumerable<CharacterStatusSimplifiedResponseDto> CharacterStatuses { get; set; }
    }
}