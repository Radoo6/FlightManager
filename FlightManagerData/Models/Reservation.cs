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
        public Flight Flight { get; set; }
        public List<Passenger> Passengers { get; set; }
        public string  Mail { get; set; }
      
        
    }
}
