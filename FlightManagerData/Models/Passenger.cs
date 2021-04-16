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
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Second name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string SecondName { get; set; }

        [Display(Name = "Last name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string LastName { get; set; }


        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Egn { get; set; }

        [Display(Name = "Telephone number")]
        [RegularExpression(@"^((\+359)|0)(8)([789][0-9]{3})([0-9]{4})$",
                            ErrorMessage = "Please enter a valid phone number")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string TelephoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Nationality { get; set; }

        public bool IsBusiness { get; set; }
    }
}
