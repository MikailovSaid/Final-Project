using Microsoft.AspNetCore.Identity;

namespace Razzi.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
