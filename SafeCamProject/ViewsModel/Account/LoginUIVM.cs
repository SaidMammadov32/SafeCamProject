using System.ComponentModel.DataAnnotations;

namespace SafeCamProject.ViewsModel.Account
{
    public class LoginUIVM
    {
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
