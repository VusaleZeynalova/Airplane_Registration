using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TicketNumber { get; set; }
        public NewFlight NewFlight { get; set; }
        [ForeignKey("NewFlight")]
        public int NewFlightId { get; set; }
        public Passenger Passenger { get; set; }
        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }


    }
}
