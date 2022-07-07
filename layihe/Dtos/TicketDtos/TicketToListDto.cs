using layihe.Dtos.FlightDtos;
using layihe.Dtos.PassengerDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Dtos.TicketDtos
{
    public class TicketToListDto
    {
        public int TicketId { get; set; }
        public int TicketNumber { get; set; }
        public FlightToListDto NewFlight { get; set; }
        [ForeignKey("NewFlight")]
        public int NewFlightId { get; set; }
        public PassengerToListDto Passenger { get; set; }
        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }

    }
}
