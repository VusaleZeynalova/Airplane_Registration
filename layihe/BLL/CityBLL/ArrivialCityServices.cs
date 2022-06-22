using AutoMapper;
using layihe.AdminUnitOfWork;
using layihe.Dtos.CityDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.CityBLL
{
    public class ArrivialCityServices : IArrivialCityService
    {
        private readonly ICityUnitOfWork _cityUnitOfWork;
        private readonly IMapper _mapper;
        public ArrivialCityServices(ICityUnitOfWork cityUnitOfWork,IMapper mapper)
        {
            _cityUnitOfWork = cityUnitOfWork;
            _mapper = mapper;
        }
        public async Task Addsync(ArrivialToAddDto arrivialToAddDto)
        {
            ArrivialCity arrivialCity = _mapper.Map<ArrivialCity>(arrivialToAddDto);
            await _cityUnitOfWork.ArrivialCityRepository.Addsync(arrivialCity);
            await _cityUnitOfWork.Commit();
        }
    }
}
