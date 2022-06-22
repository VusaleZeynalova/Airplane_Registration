using layihe.Dtos.CityDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Dtos.FlightDtos
{
    public class FlightToAddDto
    {
        public List<DepartureToListDto> DepartureCities { get; set; }
        [ForeignKey("DepartureCity")]
        public int DepartureCityId { get; set; }
        public List<ArrivialToListDto> ArrivialCities { get; set; }
        [ForeignKey("ArrivialCity")]
        public int ArrivialCityId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivialTime { get; set; }
        public int Capacity { get; set; }
        public int SeatingCapacity { get; set; }
        public float Price { get; set; }

    }
}
