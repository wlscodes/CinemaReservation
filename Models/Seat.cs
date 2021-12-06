using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Models
{
    public class Seat
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        public Guid HallID { get; set; }

        [Required]
        [Range(0, short.MaxValue)]
        [Display(Name = "Rząd")]
        public short Row { get; set; }

        [Required]
        [Range(0, short.MaxValue)]
        [Display(Name = "Miejsce")]
        public short Column { get; set; }

        [Display(Name = "Sala")]
        public virtual Hall Hall { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
