using AutoMapper;
using layihe.Dtos;
using layihe.Dtos.CityDtos;
using layihe.Dtos.FlightDtos;
using layihe.Dtos.PassengerDtos;
using layihe.Dtos.PilotDtos;
using layihe.Dtos.TicketDtos;
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
            CreateMap<PassengerToAddDto, Passenger>();
            CreateMap<Passenger, PassengerToListDto>();
            CreateMap<FlightToSerarchDto, NewFlight>().ReverseMap();
            CreateMap<NewFlight, FlightToListDto>().ReverseMap();
            CreateMap<TicketToAddDto, Ticket>().ReverseMap();
            CreateMap<Ticket, TicketToListDto>().ReverseMap();
            CreateMap<PilotToAddDto, Pilot>();
            CreateMap<Pilot, PilotToListDto>();

        }
    }
}
