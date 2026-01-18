using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Team
{
    public class TeamUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public int ProfessionId { get; set; }
    }
}
