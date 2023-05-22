using System.ComponentModel.DataAnnotations;

namespace Progress.Application.Persistence.Entities
{
    public class BasicInformation
    {
        [Required]
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
