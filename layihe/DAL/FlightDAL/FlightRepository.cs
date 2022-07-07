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

        public async Task Delete(int id)
        {
            var result = await _testDbContext.NewFlights.FindAsync(id);
             _testDbContext.NewFlights.Remove(result);
        }

        public async Task<List<NewFlight>> Find(int depId, int toId, string date)
        {
            if (depId != 0 && toId != 0 && date!=null)
            {
              
                List<NewFlight> newFlights = await _testDbContext.NewFlights.Where(m => m.DepartureCityId == depId && m.ArrivialCityId == toId &&(m.DepartureTime).Day==Convert.ToDateTime(date).Day&& (m.DepartureTime).Month== Convert.ToDateTime(date).Month&& (m.DepartureTime).Year
                == Convert.ToDateTime(date).Year).Include(m => m.DepartureCity).Include(m => m.ArrivialCity).ToListAsync();
                return newFlights;
            }
            else
            {
                List<NewFlight> newFlights = await _testDbContext.NewFlights.Include(m => m.DepartureCity).Include(m => m.ArrivialCity).ToListAsync();
                return newFlights;
            }

        }

        public async Task<List<NewFlight>> Get()
        {
            return await _testDbContext.NewFlights.Include(m => m.DepartureCity).Include(m => m.ArrivialCity).OrderBy(m=>m.DepartureTime).ToListAsync();
        }

        public async Task<List<NewFlight>> Get(int depId)
        {
            return await _testDbContext.NewFlights.Where(m => m.DepartureCityId == depId).Include(m => m.DepartureCity).Include(m => m.ArrivialCity).ToListAsync();
        }

        public async Task<NewFlight> GetFlight(int id)
        {
            return await _testDbContext.NewFlights.FindAsync(id);
        }

    
    }
}
