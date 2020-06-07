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
   // [Authorize(Roles = "Student")]
    public class DeleteModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;

        public DeleteModel(EsperiaHelp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lesson Lesson { get; set; }

        /*public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lesson = await _context.Lesson
                .Include(l => l.ApplicationUser)
                .Include(l => l.Classroom).FirstOrDefaultAsync(m => m.Id == id);

            if (Lesson == null)
            {
                return NotFound();
            }
            return Page();
        }*/

        public IActionResult OnGet()
        {
            return Page();
        }

        /*public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lesson = await _context.Lesson.FindAsync(id);

            if (Lesson != null)
            {
                Lesson.N_participants = Lesson.N_participants + 1; //si aggiunge uno studente alla lezione
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }*/

        public IActionResult OnPost()
        {
            return RedirectToPage("./Index");
        }
    }
}
