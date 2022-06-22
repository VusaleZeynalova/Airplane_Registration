using layihe.DAL.FlightDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
    public interface IFlightUnitOfWork
    {
        public IFlightRepository FlightRepository { get; set; }
        Task Commit();
    }
}
