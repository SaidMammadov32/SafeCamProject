using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Profession
{
    public class ProfessionUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
