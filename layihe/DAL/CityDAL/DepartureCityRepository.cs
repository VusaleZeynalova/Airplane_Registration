using layihe.DataContext;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.CityDAL
{
    public class DepartureCityRepository : IDepartureCityRepository
    {
        private readonly TestDbContext _testDbContext;
        public DepartureCityRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        public async Task Addsync(DepartureCity departureCities )
        {
            await _testDbContext.AddAsync(departureCities);
        }
    }
}
