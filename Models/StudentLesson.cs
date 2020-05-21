using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsperiaHelp.Models
{
    public class StudentLesson //classe che rappresenta la relazione N a N tra gli studenti e gli incontri creati dagli insegnanti
    {
        [Key]
        public int Id { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; } //FK dello studente
        
        public Lesson Lesson { get; set; } //FK dell'incontro
    }
}
