using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.Models
{
    public class Profession : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
