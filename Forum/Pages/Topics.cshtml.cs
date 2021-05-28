using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Forum.Data;
using Forum.Models;

namespace Forum.Pages
{
    [Authorize]
    [BindProperties]
    public class TopicsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TopicsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Topic NewTopic { get; set; } = new Topic();
        public List<Topic> Topics { get; set; } = new List<Topic>();

        public void OnGet()
        {
            Topics = _context.Topic.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Topic.AddAsync(NewTopic);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
