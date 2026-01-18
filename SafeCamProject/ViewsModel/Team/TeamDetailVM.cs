using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Team
{
    public class TeamDetailVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public int ProfessionId { get; set; }
        public string Profession { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
