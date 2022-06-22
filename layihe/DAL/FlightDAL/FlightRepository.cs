using layihe.DataContext;
using layihe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.FlightDAL
{
    public class FlightRepository : IFlightRepository
    {
        private readonly TestDbContext _testDbContext;
        public FlightRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        public async Task Addsync(NewFlight newFlight)
        {
            await _testDbContext.AddAsync(newFlight);
        }

        public async Task<List<NewFlight>> Get()
        {
            return await _testDbContext.NewFlights.Include(m=>m.DepartureCity).Include(m=>m.ArrivialCity).ToListAsync();       }
    }
}
