namespace Progress.Application.Usecases.Status.Add
{
    public class CharacterClassRequestDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ClassModifierRequestDto[] Modifiers { get; set; }
        public SkillRequestDto[] Skills { get; set; }
    }
}