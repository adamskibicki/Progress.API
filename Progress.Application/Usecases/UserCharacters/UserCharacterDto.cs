namespace Progress.Application.Usecases.UserCharacters
{
    public class UserCharacterDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTimeOffset LastEdited { get; set; }
        public Guid StatusId { get; set; }
    }
}