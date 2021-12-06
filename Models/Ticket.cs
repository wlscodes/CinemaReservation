using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Models
{
    public class Ticket
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid EventID {get; set;}

        [Required]
        public Guid SeatID { get; set; }

        [Required]
        [Display(Name = "Data zakupu")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime BougthDate { get; set; }

        [Display(Name = "Wydarzenie")]
        public virtual Event Event { get; set; }

        [Display(Name = "Miejsce")]
        public virtual Seat Seat { get; set; }
    }
}
