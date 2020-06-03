using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsperiaHelp.Models
{
    public class Lesson: IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } //data incontro

        [Required]
        [Display(Name = "Start time")]
        
        public DateTime StartTime { get; set; } //ora inizio

        [Required]
        [Display(Name = "End time")]
        public DateTime EndTime { get; set; } //ora fine

        [Range(1, 8)]
        [Display(Name = "Number of participants")]
        public int N_participants { get; set; } //numero partecipanti alll'incontro

        [Display(Name = "Teacher")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } //identificativo docente dell'incontro

        [Display(Name = "Classroom")]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; } //identificativo dell'aula dove si svolgerà l'incontro

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) //controllo data
        {
            if (StartTime >= EndTime)
            {
                yield return new ValidationResult(
                    $"L'ora di inizio incontro deve essere precedente a quella di fine");
            }
        }


    }
}
