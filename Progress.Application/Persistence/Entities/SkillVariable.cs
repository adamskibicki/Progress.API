using Progress.Application.Persistence.Common;
using Progress.Application.Usecases.Status;

namespace Progress.Application.Persistence.Entities
{
    public class SkillVariable : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int BaseValue { get; set; }
        public string Unit { get; set; }
        /// <summary>
        /// How it affects other calculations
        /// </summary>
        public CategoryCalculationType CategoryCalculationType { get; set; }
        public string BaseVariableName { get; set; }
        /// <summary>
        /// How variable is calculated itself
        /// </summary>
        public VariableCalculationType VariableCalculationType { get; set; }
        public List<SkillVariableStat> AffectedStats { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
