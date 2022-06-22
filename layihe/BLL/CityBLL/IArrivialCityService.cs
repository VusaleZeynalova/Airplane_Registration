using layihe.Dtos.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.CityBLL
{
   public interface IArrivialCityService
    {
        Task Addsync(ArrivialToAddDto arrivialToAddDto);
    }
}
