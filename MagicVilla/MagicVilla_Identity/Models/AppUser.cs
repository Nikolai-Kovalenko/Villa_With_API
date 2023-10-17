using Microsoft.AspNetCore.Identity;

namespace MagicVilla_Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
