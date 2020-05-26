using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsperiaHelp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }        //Nome utente

        public string Surname { get; set; }     //Cognome utente

        public int SubjectId { get; set; }

        public Subject Subject{ get; set; }    //per i docenti (per studenti il valore sarà null)

        public int ClassId { get; set; }
        public Class Class { get; set; }        //per studenti

        public ICollection<Lesson> lessons;
    }
}
