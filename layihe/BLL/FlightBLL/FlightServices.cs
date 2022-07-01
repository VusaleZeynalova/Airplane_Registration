using AutoMapper;
using layihe.AdminUnitOfWork;
using layihe.DataContext;
using layihe.Dtos.CityDtos;
using layihe.Dtos.FlightDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.FlightBLL
{
    public class FlightServices : IFlightServices
    {
        private readonly IFlightUnitOfWork _flightUnitOfWork;
        private readonly TestDbContext _testDbContext;
        private readonly IMapper _mapper;
        public FlightServices(IFlightUnitOfWork flightUnitOfWork,IMapper mapper,TestDbContext testDbContext)
        {
            _flightUnitOfWork = flightUnitOfWork;
            _mapper = mapper;
            _testDbContext = testDbContext;

        }
        public async Task Addasync(FlightToAddDto flightToAddDto)
        {
            NewFlight newFlight = _mapper.Map<NewFlight>(flightToAddDto);
            await _flightUnitOfWork.FlightRepository.Addsync(newFlight);
            await _flightUnitOfWork.Commit();
        }

        public async Task<List<FlightToListDto>> Find(int depId, int toId, string date)
        {
            if (depId != null && toId != null && date != null)
            {
                List<NewFlight> flights = await _flightUnitOfWork.FlightRepository.Find(depId, toId,date);
                List<FlightToListDto> flightToListDtos=  _mapper.Map<List<FlightToListDto>>(flights);
                return flightToListDtos;
            }
            else
            {
                List<NewFlight> flights = await _flightUnitOfWork.FlightRepository.Find(depId, toId,date);
                List<FlightToListDto> flightToListDtos = _mapper.Map<List<FlightToListDto>>(flights);
                return flightToListDtos;
            }

        }

        public async Task<List<FlightToListDto>> Get()
        {
            List<NewFlight> newFlights = await _flightUnitOfWork.FlightRepository.Get();
            List<FlightToListDto> flightToListDtos = _mapper.Map<List<FlightToListDto>>(newFlights);
            return flightToListDtos;
        }

        public async Task<List<FlightToListDto>> Get(int depId)
        {
            List<NewFlight> flights = await _flightUnitOfWork.FlightRepository.Get(depId);
            List<FlightToListDto> flightToListDtos = _mapper.Map<List<FlightToListDto>>(flights);
            return flightToListDtos;
        }

        public async Task<FlightToAddDto> InnerModel()        {
            FlightToAddDto flightToAddDto = new FlightToAddDto();
            flightToAddDto.DepartureCities = _mapper.Map<List<DepartureToListDto>>(_testDbContext.DepartureCities.ToList());
            flightToAddDto.ArrivialCities = _mapper.Map<List<ArrivialToListDto>>(_testDbContext.ArrivialCities.ToList());
            return flightToAddDto;
        }

        
    }
}
