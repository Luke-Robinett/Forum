using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

namespace Forum.Pages.Admin.Topics
{
    public class DetailsModel : PageModel
    {
        private readonly Forum.Data.ApplicationDbContext _context;

        public DetailsModel(Forum.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = await _context.Topic.FirstOrDefaultAsync(m => m.ID == id);

            if (Topic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
