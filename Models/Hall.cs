using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Models
{
    public class Hall
    {
        [Required]
        public Guid ID { get; set; }
        
        [Required(ErrorMessage = "Nazwa sali jest wymagana")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Nazwa sali powinna mieć długość {2}-{1} znaków")]
        [Display(Name = "Nazwa sali")]
        public string Name { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
