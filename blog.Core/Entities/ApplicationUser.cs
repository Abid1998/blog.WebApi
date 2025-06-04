

using Microsoft.AspNetCore.Identity;

namespace blog.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
