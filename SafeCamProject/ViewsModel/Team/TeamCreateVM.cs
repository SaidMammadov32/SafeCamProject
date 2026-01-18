using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Team
{
    public class TeamCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
        public int ProfessionId { get; set; }

    }
}
