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
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;

        public DetailsModel(EsperiaHelp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Classroom Classroom { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await _context.Classroom.FirstOrDefaultAsync(m => m.Id == id);

            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
