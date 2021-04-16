using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagerData.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name ="Confirm password")]
        [Required]
        public string ConfirmPassword { get; set; }

        [Column(TypeName = "nvarchar(100)")]
       [Required]
        [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+",
                            ErrorMessage = "Please enter a valid email address")]
        public string Mail { get; set; }

        [Display(Name ="First name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Column(TypeName = "nvarchar(100)")]
       [Required]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Egn { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Adress { get; set; }

        [Display(Name = "Telephone number")]
        [RegularExpression(@"^((\+359)|0)(8)([789][0-9]{3})([0-9]{4})$",
                            ErrorMessage = "Please enter a valid phone number")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string TelephoneNumber { get; set; }


        public bool IsAdmin { get; set; }

    }
}
