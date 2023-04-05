using Progress.Application.Persistence.Common;
using Progress.Application.Usecases.Status.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Application.Persistence.Entities
{
    public class Skill : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Tier { get; set; }
        public bool Enhanced { get; set; }
        public SkillType Type { get; set; }
        public List<TierDescription> TierDescriptions { get; set; }
        public List<Category> Categories { get; set; }
        public List<SkillVariable> Variables { get; set; }
        public Guid CharacterClassId { get; set; }
        public CharacterClass CharacterClass { get; set; }
    }
}
