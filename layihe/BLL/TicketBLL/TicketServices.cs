using AutoMapper;
using layihe.AdminUnitOfWork;
using layihe.DAL.CityDAL;
using layihe.DAL.FlightDAL;
using layihe.DAL.PassengerDAL;
using layihe.Dtos.FlightDtos;
using layihe.Dtos.TicketDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.TicketBLL
{
    public class TicketServices : ITicketServices
    {
        private readonly IMapper _mapper;
        private readonly ITicketUnitOfWork _ticketUnitOfWork;
        private readonly IFlightRepository _flightRepository;
        private readonly IArrivialCityRepository _arrivialCityRepository;
        private readonly IDepartureCityRepository _departureCityRepository;
        private readonly IPassengerRepository _passengerRepository;
        public TicketServices(IMapper mapper,IPassengerRepository passengerRepository, ITicketUnitOfWork ticketUnitOfWork,IDepartureCityRepository departureCity, IArrivialCityRepository arrivialCityRepository, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _ticketUnitOfWork = ticketUnitOfWork;
            _flightRepository = flightRepository;
            _arrivialCityRepository = arrivialCityRepository;
            _departureCityRepository = departureCity;
            _passengerRepository = passengerRepository;
        }
        public async Task Addsync(TicketToAddDto ticketToAddDto)
        {
            Ticket ticket = _mapper.Map<Ticket>(ticketToAddDto);
            NewFlight newFlight = await _flightRepository.GetFlight(ticketToAddDto.NewFlightId);
            await _arrivialCityRepository.GetArrivial(newFlight.ArrivialCityId);
            await _departureCityRepository.GetDeparture(newFlight.DepartureCityId);
            ticketToAddDto.NewFlight =_mapper.Map<FlightToListDto>(newFlight);
            newFlight.SeatingCapacity -= 1;
            await _ticketUnitOfWork.TicketRepository.Addsync(ticket);
            await _ticketUnitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            await _ticketUnitOfWork.TicketRepository.Delete(id);
            Ticket ticket  =await _ticketUnitOfWork.TicketRepository.GetById(id);
            NewFlight newFlight = await _flightRepository.GetFlight(ticket.NewFlightId);
            newFlight.SeatingCapacity += 1;
            await _ticketUnitOfWork.Commit();



        }

        public async Task<List<TicketToListDto>> Get()
        {
            List<Ticket> tickets = await _ticketUnitOfWork.TicketRepository.Get();
            List<TicketToListDto> ticketToListDtos = _mapper.Map<List<TicketToListDto>>(tickets);
            return ticketToListDtos;
        }

        public async Task<TicketToListDto> GetById(int id)
        {
            Ticket ticket = await _ticketUnitOfWork.TicketRepository.GetById(id);
            TicketToListDto ticketToListDto = _mapper.Map<TicketToListDto>(ticket);
            return ticketToListDto;
            
        }

        public  async Task<TicketToListDto> GetTicket(int ticketNumber)
        {
            Ticket ticket = await _ticketUnitOfWork.TicketRepository.GetTicket(ticketNumber);
            if (ticket != null)
            { 
                NewFlight newFlight = await _flightRepository.GetFlight(ticket.NewFlightId);
                Passenger passenger = await _passengerRepository.GetPassenger(ticket.PassengerId);
                await _arrivialCityRepository.GetArrivial(newFlight.ArrivialCityId);
                await _departureCityRepository.GetDeparture(newFlight.DepartureCityId);
                TicketToListDto ticketToListDto = _mapper.Map<TicketToListDto>(ticket);
                return ticketToListDto;
            }
            
            return _mapper.Map<TicketToListDto>(ticket);
        }
    }
}
