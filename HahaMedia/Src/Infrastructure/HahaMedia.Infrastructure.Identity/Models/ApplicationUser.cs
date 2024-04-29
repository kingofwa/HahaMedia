using Microsoft.AspNetCore.Identity;
using System;

namespace HahaMedia.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Created = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}
