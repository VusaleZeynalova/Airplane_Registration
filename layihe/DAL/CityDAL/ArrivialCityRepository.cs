using layihe.DataContext;
using layihe.Dtos.CityDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.CityDAL
{
    public class ArrivialCityRepository : IArrivialCityRepository
    {
        private readonly TestDbContext _testDbContext;
        public ArrivialCityRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        public async Task Addsync(ArrivialCity arrivialCity)
        {
            await _testDbContext.AddAsync(arrivialCity);
        }

      
    }
}
