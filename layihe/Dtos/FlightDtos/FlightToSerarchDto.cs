using layihe.Dtos.CityDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Dtos.FlightDtos
{
    public class FlightToSerarchDto
    {
        public List<DepartureToListDto> DepartureCities { get; set; }
        [ForeignKey("DepartureCity")]
        public int DepartureCityId { get; set; }
        public List<ArrivialToListDto> ArrivialCities { get; set; }
        [ForeignKey("ArrivialCity")]
        public int ArrivialCityId { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}

