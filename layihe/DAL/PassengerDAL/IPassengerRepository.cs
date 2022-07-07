using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.PassengerDAL
{
  public interface IPassengerRepository
    {
        Task Addsync(Passenger passenger);
        Task<Passenger> GetPassenger(int id);
    }
}
