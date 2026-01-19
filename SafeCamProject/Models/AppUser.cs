using Microsoft.AspNetCore.Identity;

namespace SafeCamProject.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
