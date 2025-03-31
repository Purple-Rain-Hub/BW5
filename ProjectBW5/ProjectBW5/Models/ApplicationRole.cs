using Microsoft.AspNetCore.Identity;

namespace ProjectBW5.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
