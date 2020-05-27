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
using Microsoft.AspNetCore.Identity;

namespace EsperiaHelp
{
    [Authorize(Roles = "Teacher")] //solamente gli insegnanti possono accedere a questa classe
    public class IndexModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager; //questa variabile serve per poter sapere quale è l'utente che in questo momento è loggato
        public IndexModel(EsperiaHelp.Data.ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IList<Lesson> Lesson { get;set; }
        public IList<Classroom> Classroom { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Lesson = await _context.Lesson.Where(s=>s.ApplicationUserId==user.Id).ToListAsync();
            Classroom = await _context.Classroom.ToListAsync(); 
        }
    }
}
