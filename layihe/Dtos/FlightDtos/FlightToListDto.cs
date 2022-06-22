using layihe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Dtos.FlightDtos
{
    public class FlightToListDto
    { 
        public int NewFlightId { get; set; }
        public DepartureCity DepartureCity { get; set; }
        [ForeignKey("DepartureCity")]
        public int Id { get; set; }
        public ArrivialCity ArrivialCity { get; set; }
        [ForeignKey("ArrivialCity")]
        public int ArrivialCityId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivialTime { get; set; }
        public int Capacity { get; set; }
        public int SeatingCapacity { get; set; }
        public float Price { get; set; }

    }
}
