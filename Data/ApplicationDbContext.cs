using System;
using System.Collections.Generic;
using System.Text;
using EsperiaHelp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EsperiaHelp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EsperiaHelp.Models.Classroom> Classroom { get; set; }
        public DbSet<EsperiaHelp.Models.Subject> Subject { get; set; }
        public DbSet<EsperiaHelp.Models.Lesson> Lesson { get; set; }
        public DbSet<EsperiaHelp.Models.StudentLesson> StudentLesson { get; set; }
    
}
}
