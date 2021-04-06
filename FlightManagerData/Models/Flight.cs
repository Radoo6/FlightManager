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
        [Column(TypeName = "smalldatetime")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        [Column(TypeName = "smalldatetime")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Plane Type")]
        [Column(TypeName ="nvarchar(100)")]
        public string PlaneType { get; set; }

        public string PlaneUniqueNumber { get; set; }

        [Display(Name = "Pilot name")]
        [Column(TypeName = "nvarchar(100)")]
        public string PilotName { get; set; }

        public int PassengersCapacity { get; set; }

        public int BusinessClassCapacity { get; set; }
    }
}
