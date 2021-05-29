using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Post> Posts { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
