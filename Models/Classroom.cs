using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsperiaHelp.Models
{
    public class Classroom
    {
        public int Id { get; set; } //chiave primaria che identifica univocamente un'aula

        public string Name { get; set; } //nome dell'aula
        
        public ICollection<Lesson> lessons;
    }
}
