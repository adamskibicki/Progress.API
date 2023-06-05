namespace Progress.Application.Usecases.Status.Add
{
    public class CharacterStatusRequestDto
    {
        public GeneralInformationRequestDto GeneralInformation { get; set; }

        public CharacterClassRequestDto[] Classes { get; set; }
    }
}
