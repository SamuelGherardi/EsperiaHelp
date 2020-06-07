using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EsperiaHelp.Data;
using EsperiaHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EsperiaHelp.Pages.Teacher
{
   // [Authorize(Roles = "Teacher")] //solamente gli insegnanti possono accedere a questa classe
    public class CreateModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager; //questa variabile serve per poter sapere quale è l'utente che in questo momento è loggato

        public CreateModel(EsperiaHelp.Data.ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        public SelectList Classrooms { get; set; } //elementi per poter mostrare all'insegnante la lista delle classi disponibili per l'incontro
        [BindProperty(SupportsGet = true)]
        public string ClassroomLesson { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }


        public async Task <IActionResult> OnGetAsync()
        {
            IQueryable<string> classroomQuery = from m in _context.Classroom  //Query per l'aula
                                              orderby m.Name
                                              select m.Name;
            Classrooms = new SelectList(await classroomQuery.Distinct().ToListAsync());

            return Page();
        }

        [BindProperty]
        public Lesson Lesson { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ApplicationUser user = null;
            user = await _userManager.GetUserAsync(User);
            if (user.Id == null)
            {
                return NotFound();
            }
            Lesson.ApplicationUserId= user.Id; //La lezione che viene creata dall'insegnante avrà il suo Identificativo
            foreach(var item in _context.Classroom)
            {
                if (ClassroomLesson == item.Name)
                {
                    Lesson.ClassroomId = item.Id; //La lezione che viene creata dall'insegnante contiene la FK dell'aula dove si svolgerà
                }
            }

            /*foreach(var item in _context.Lesson) //controllo per evitare sovrapposizioni tra le diverse lezioni
            {
                if (item.Date == Lesson.Date)
                {
                    if ((item.StartTime>=Lesson.StartTime)&&(item.EndTime>=Lesson.EndTime) && (Lesson.ApplicationUserId == item.ApplicationUserId) || (Lesson.StartTime >= item.StartTime) && (Lesson.EndTime >= item.EndTime)&&(Lesson.ApplicationUserId==item.ApplicationUserId))
                    {
                        return NotFound(); //da migliorare con messaggio di errore
                    }
                    else if((item.StartTime <= Lesson.StartTime) && (item.EndTime <= Lesson.EndTime) && (Lesson.ClassroomId == item.ClassroomId) || (Lesson.StartTime <= item.StartTime) && (Lesson.EndTime <= item.EndTime) && (Lesson.ClassroomId == item.ClassroomId))
                    {
                        return NotFound(); //da migliorare con messaggio di errore
                    }

                }

            }*/
            
            _context.Lesson.Add(Lesson);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
