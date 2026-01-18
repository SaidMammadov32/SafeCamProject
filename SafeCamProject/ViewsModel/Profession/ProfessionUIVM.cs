using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Profession
{
    public class ProfessionUIVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
