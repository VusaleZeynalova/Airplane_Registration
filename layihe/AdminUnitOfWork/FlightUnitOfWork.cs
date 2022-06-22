using layihe.DAL.FlightDAL;
using layihe.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
    public class FlightUnitOfWork : IFlightUnitOfWork
    {
        private readonly TestDbContext _testDbContext;
        public IFlightRepository FlightRepository { get; set; }
        public FlightUnitOfWork(TestDbContext testDbContext,IFlightRepository flightRepository )
        {
            _testDbContext = testDbContext;
            FlightRepository = flightRepository;
        }
        public  async Task Commit()
        {
            await _testDbContext.SaveChangesAsync();
        }
    }
}
