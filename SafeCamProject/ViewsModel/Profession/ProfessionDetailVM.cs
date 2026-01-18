using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Profession
{
    public class ProfessionDetailVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
