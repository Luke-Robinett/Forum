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
    public class RepliesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RepliesModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Reply NewReply { get; set; } = new Reply();
        [BindProperty]
        public List<Reply> Replies { get; set; } = new List<Reply>();

        public async Task<IActionResult> OnGetAsync(int postID)
        {
            var post = await _context.Post.FindAsync(postID);
            if (post== null)
            {
                return NotFound("No matching post.");
            }
            var user = await _userManager.GetUserAsync(User);

            NewReply.ApplicationUserID = user.Id;
            NewReply.PostID = postID;
            NewReply.Post = post;

            Replies = _context.Reply
                .Include(r => r.ApplicationUser)
                .Include(r => r.Post)
                .Where(r => r.PostID== postID)
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Reply.Add(NewReply);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
