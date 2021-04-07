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
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name ="Confirm password")]
        public string ConfirmPassword { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Mail { get; set; }

        [Display(Name ="First name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Egn { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Adress { get; set; }

        [Display(Name = "Telephone number")]
        [Column(TypeName = "nvarchar(100)")]
        public string TelephoneNumber { get; set; }

        public bool IsAdmin { get; set; }

    }
}
