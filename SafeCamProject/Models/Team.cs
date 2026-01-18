using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.Models
{
    public class Team : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
    }
}
