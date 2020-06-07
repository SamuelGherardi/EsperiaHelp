using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EsperiaHelp.Data;
using EsperiaHelp.Models;
using Microsoft.AspNetCore.Authorization;

namespace EsperiaHelp.Pages.Student
{
    //[Authorize(Roles = "Student")]
    public class IndexModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;

        public IndexModel(EsperiaHelp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Lesson> Lesson { get;set; }

        public async Task OnGetAsync()
        {
            Lesson = await _context.Lesson
                .Include(l => l.ApplicationUser)
                .Include(l => l.Classroom).ToListAsync();
        }
    }
}
