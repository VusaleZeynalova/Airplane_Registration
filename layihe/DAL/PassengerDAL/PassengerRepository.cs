using layihe.DataContext;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.PassengerDAL
{


    public class PassengerRepository : IPassengerRepository
    {
        private readonly TestDbContext _testDbContext;
        public PassengerRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;

        }
        public  async Task Addsync(Passenger passenger)
        {
             await  _testDbContext.Passengers.AddAsync(passenger);
            
        }

        public async Task<Passenger> GetPassenger(int id)
        {
            return await _testDbContext.Passengers.FindAsync(id);
        }
    }
}
