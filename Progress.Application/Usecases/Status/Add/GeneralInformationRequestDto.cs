namespace Progress.Application.Usecases.Status.Add
{
    public class GeneralInformationRequestDto
    {
        public BasicInfoRequestDto BasicInfo { get; set; }
        public ResourceRequestDto[] Resources { get; set; }
        public StatsRequestDto Stats { get; set; }
    }

    public record StatsRequestDto(StatRequestDto[] Stats, int UnspentStatpoints);

    public record StatRequestDto(Guid? Id, string Name, int Value, bool IsHidden);

    public record ResourceRequestDto(Guid? BaseStatId, string DisplayName, int ResourcePointsPerBaseStatPoint);
}
