using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsperiaHelp.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } //data incontro
        public DateTime StartTime { get; set; } //ora inizio
        public DateTime EndTime { get; set; } //ora fine
        public int N_participants { get; set; } //numero partecipanti alll'incontro
        public ApplicationUser ApplicationUser { get; set; } //identificativo docente dell'incontro
        public Classroom Classroom { get; set; } //identificativo dell'aula dove si svolgerà l'incontro
    }
}
