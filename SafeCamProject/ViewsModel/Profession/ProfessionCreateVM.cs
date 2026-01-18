using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Profession
{
    public class ProfessionCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
