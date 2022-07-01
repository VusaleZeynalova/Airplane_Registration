using AutoMapper;
using layihe.Dtos.CityDtos;
using layihe.Dtos.FlightDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.Mapper
{
    public class TestMapper:Profile
    {
        public TestMapper()
        {
            CreateMap<ArrivialToAddDto, ArrivialCity>();
            CreateMap<ArrivialCity, ArrivialToListDto>();
            CreateMap<DepatureCityToAddDto, DepartureCity>();
            CreateMap<DepartureCity, DepartureToListDto>();
            CreateMap<FlightToAddDto, NewFlight>();
            CreateMap<FlightToSerarchDto, NewFlight>().ReverseMap();
            CreateMap<NewFlight, FlightToListDto>();
        }
    }
}
