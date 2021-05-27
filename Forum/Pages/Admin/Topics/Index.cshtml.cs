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
    public class IndexModel : PageModel
    {
        private readonly Forum.Data.ApplicationDbContext _context;

        public IndexModel(Forum.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Topic> Topic { get;set; }

        public async Task OnGetAsync()
        {
            Topic = await _context.Topic.ToListAsync();
        }
    }
}
