﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EsperiaHelp.Data;
using EsperiaHelp.Models;
using Microsoft.AspNetCore.Authorization;

namespace EsperiaHelp
{
    [Authorize(Roles = "teacher")] //solamente gli insegnanti possono accedere a questa classe
    public class DetailsModel : PageModel
    {
        private readonly EsperiaHelp.Data.ApplicationDbContext _context;

        public DetailsModel(EsperiaHelp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Lesson Lesson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lesson = await _context.Lesson.FirstOrDefaultAsync(m => m.Id == id);

            if (Lesson == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
