using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagerData.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public Flight Flight { get; set; }
        public List<Passenger> Passengers { get; set; }/// <summary>
        /// bullshit
        /// </summary>

        [Display(Name = "E-mail")]
        [Column(TypeName = "nvarchar(100)")]
        [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+",
                            ErrorMessage = "Please enter a valid email address")]
        [Required]
        public string Mail { get; set; }
    }
}
