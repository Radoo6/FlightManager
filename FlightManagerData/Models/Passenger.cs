using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagerData.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Display(Name = "First name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Display(Name = "Second name")]
        [Column(TypeName = "nvarchar(100)")]
        public string SecondName { get; set; }

        [Display(Name = "Last name")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }


        [Column(TypeName = "nvarchar(10)")]
        public string Egn { get; set; }

        [Display(Name = "Telephone number")]
        [Column(TypeName = "nvarchar(100)")]
        public string TelephoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nationality { get; set; }

        public bool IsBusiness { get; set; }
    }
}
