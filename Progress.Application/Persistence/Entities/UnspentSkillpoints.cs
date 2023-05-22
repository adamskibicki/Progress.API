using System.ComponentModel.DataAnnotations;

namespace Progress.Application.Persistence.Entities
{
    public class UnspentSkillpoints
    {
        [Required]
        public int CoreSkillpoints { get; set; }
        [Required]
        public int FourthTierSkillpoints { get; set; }
        [Required]
        public int ThirdTierGeneralSkillpoints { get; set; }
        [Required]
        public int FourthTierGeneralSkillpoints { get; set; }
    }
}
