using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Models
{
    public class Event
    {
        [Key]
        public Guid ID { get; set; }
        
        [Required(ErrorMessage = "Nazwa wydarzenia jest wymagana")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Nazwa wydarzenia powinna mieć długość {2}-{1} znaków")]
        [Display(Name = "Nazwa wydarzenia")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [Display(Name = "Data rozpoczęcia")]
        public DateTime BeginTime { get; set; }

        [Required(ErrorMessage = "Data zakończenia jest wymagana")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [Display(Name = "Data zakończenia")]
        public DateTime FinishTime { get; set; }

        [Required(ErrorMessage = "Sala jest wymagana")]
        [Display(Name = "Sala")]
        public Guid HallID { get; set; }

        [Display(Name = "Sala")]
        public virtual Hall Hall { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
