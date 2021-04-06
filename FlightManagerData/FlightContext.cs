using FlightManagerData.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagerData
{
    public class FlightContext:DbContext
    {
        public FlightContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
