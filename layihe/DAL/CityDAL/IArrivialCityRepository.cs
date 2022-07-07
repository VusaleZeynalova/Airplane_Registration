using layihe.Dtos.CityDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.CityDAL
{
   public interface IArrivialCityRepository
    {
        Task Addsync(ArrivialCity arrivialCity);
       Task GetArrivial(int id);
    }
}
