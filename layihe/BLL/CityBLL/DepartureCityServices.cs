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
    public class DepartureCityServices : IDepartureCityServices
    {
        private readonly ICityUnitOfWork _cityUnitOfWork;
        private readonly IMapper _mapper;
        public DepartureCityServices(ICityUnitOfWork cityUnitOfWork,IMapper mapper)
        {
            _cityUnitOfWork = cityUnitOfWork;
            _mapper = mapper;
        }
        public  async Task Addsync(DepatureCityToAddDto depatureCityToAddDto)
        {
            DepartureCity cities = _mapper.Map<DepartureCity>(depatureCityToAddDto);
            await _cityUnitOfWork.CityRepository.Addsync(cities);
            await _cityUnitOfWork.Commit();
        }
    }
}
