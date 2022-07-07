using layihe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DataContext
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext>options):base(options)
        {

        }  
     public   DbSet<ArrivialCity> ArrivialCities { get; set; }
     public   DbSet<DepartureCity> DepartureCities { get; set; }
     public  DbSet<NewFlight> NewFlights { get; set; }
     public  DbSet<Passenger> Passengers { get; set; }
     public  DbSet<Ticket>Tickets { get; set; }
     public  DbSet<Pilot> Pilots { get; set; }
    }
}
