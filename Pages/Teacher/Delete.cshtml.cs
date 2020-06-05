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

namespace EsperiaHelp.Pages.Teacher
{
   // [Authorize(Roles = "Teacher")] //solamente gli insegnanti possono accedere a questa classe
    public class DeleteModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;

        public DeleteModel(EsperiaHelp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lesson Lesson { get; set; }
        public Classroom Classroom { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lesson = await _context.Lesson.FirstOrDefaultAsync(m => m.Id == id);
            Classroom = await _context.Classroom.FirstOrDefaultAsync(m => m.Id == Lesson.ClassroomId);
            if (Lesson == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lesson = await _context.Lesson.FindAsync(id);

            if (Lesson != null)
            {
                _context.Lesson.Remove(Lesson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
