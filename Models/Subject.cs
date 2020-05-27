using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsperiaHelp.Models
{
    public class Subject
    {
        public int Id { get; set; } //chiave primaria che identifica univocamente una materia

        public string Name { get; set; } //nome della materia

        public ICollection<ApplicationUser> applicationUsers;
    }
}
