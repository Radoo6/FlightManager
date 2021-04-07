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
        public string StartLocation { get; set; }

        [Display(Name = "End location")]
        [Column(TypeName = "nvarchar(100)")]
        public string EndLocation { get; set; }

        [Display(Name = "Start time")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "smalldatetime")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        //[Column(TypeName = "smalldatetime")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Plane Type")]
        [Column(TypeName ="nvarchar(100)")]
        public string PlaneType { get; set; }

        [Display(Name = "Plane Unique Number")]
        public string PlaneUniqueNumber { get; set; }

        [Display(Name = "Pilot name")]
        [Column(TypeName = "nvarchar(100)")]
        public string PilotName { get; set; }

        [Display(Name = "Passengers Capacity")]
        public int PassengersCapacity { get; set; }

        [Display(Name = "Business Class Capacity")]
        public int BusinessClassCapacity { get; set; }
    }
}
