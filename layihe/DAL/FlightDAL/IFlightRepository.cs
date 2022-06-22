using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.FlightDAL
{
  public  interface IFlightRepository
    {
        Task Addsync(NewFlight newFlight);
        Task<List<NewFlight>> Get();
    }
}
