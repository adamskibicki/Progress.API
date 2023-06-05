namespace Progress.Application.Usecases.Status.Add
{
    public class CharacterClassRequestDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public dynamic[] Modifiers { get; set; }
        public dynamic[] Skills { get; set; }
    }
}