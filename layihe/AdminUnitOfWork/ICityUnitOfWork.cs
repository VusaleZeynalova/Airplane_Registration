using layihe.DAL.CityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
   public interface ICityUnitOfWork
    {
        public IDepartureCityRepository CityRepository { get; set; }
        public IArrivialCityRepository ArrivialCityRepository { get; set; }
        Task Commit();
    }
}
