using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Team
{
    public class TeamUIVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public string Profession { get; set; }
    }
}
