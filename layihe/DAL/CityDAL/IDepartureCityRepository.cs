using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.CityDAL
{
   public interface IDepartureCityRepository
    {
        Task Addsync(DepartureCity departureCities);
        Task GetDeparture(int id);

    }
}
