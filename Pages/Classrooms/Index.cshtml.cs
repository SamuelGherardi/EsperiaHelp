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

namespace EsperiaHelp.Pages.Classrooms
{
   // [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;

        public IndexModel(EsperiaHelp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Classroom> Classroom { get;set; }

        public async Task OnGetAsync()
        {
            Classroom = await _context.Classroom.ToListAsync();
        }
    }
}
