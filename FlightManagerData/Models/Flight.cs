using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagerData.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Display(Name ="Start location")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string StartLocation { get; set; }

        [Display(Name = "End location")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string EndLocation { get; set; }

        [Display(Name = "Start time")]
        [Required]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        [Required]
        //[Column(TypeName = "smalldatetime")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Plane Type")]
        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string PlaneType { get; set; }

        [Display(Name = "Plane Unique Number")]
        [Required]
        public string PlaneUniqueNumber { get; set; }

        [Display(Name = "Pilot name")]
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string PilotName { get; set; }

        [Display(Name = "Passengers Capacity")]
        [Required]
        public int PassengersCapacity { get; set; }

        [Display(Name = "Business Class Capacity")]
        [Required]
        public int BusinessClassCapacity { get; set; }
    }
}
