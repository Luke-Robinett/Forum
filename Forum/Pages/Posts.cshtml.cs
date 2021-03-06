using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Pages
{
    [Authorize]
    public class PostsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Post NewPost { get; set; } = new Post();
        [BindProperty]
        public List<Post> Posts { get; set; } = new List<Post>();

        public async Task<IActionResult> OnGetAsync(int topicID)
        {
            var topic = await _context.Topic.FindAsync(topicID);
            if (topic == null)
            {
                return NotFound("No matching topic.");
            }
            var user = await _userManager.GetUserAsync(User);

            NewPost.ApplicationUserID = user.Id;
            NewPost.TopicID = topicID;

            Posts = _context.Post
                .Include(p => p.ApplicationUser)
                .Include(p => p.Topic)
                .Where(p => p.Topic.ID == topicID)
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Post.Add(NewPost);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
