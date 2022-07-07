using AutoMapper;
using layihe.AdminUnitOfWork;
using layihe.Dtos;
using layihe.Dtos.PassengerDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.PassengerBLL
{
    public class PassengerServices : IPassengerServices
    {
        private readonly IMapper _mapper;
        private readonly IPassengerUnitOfWork _passengerUnitOfWork;
        public PassengerServices(IMapper mapper,IPassengerUnitOfWork passengerUnitOfWork)
        {
            _mapper = mapper;
            _passengerUnitOfWork = passengerUnitOfWork;

        }

        public async Task Addsync(PassengerToAddDto passengerToAddDto)
        {
            Passenger passenger = _mapper.Map<Passenger>(passengerToAddDto);
            await _passengerUnitOfWork.PassengerRepository.Addsync(passenger);
            await _passengerUnitOfWork.Commit();
        }

        public async Task<PassengerToListDto> GetPassenger(int id)
        {
            Passenger passenger = await _passengerUnitOfWork.PassengerRepository.GetPassenger(id);
            PassengerToListDto passengerToListDto = _mapper.Map<PassengerToListDto>(passenger);
            return passengerToListDto;
        }
    }
}
