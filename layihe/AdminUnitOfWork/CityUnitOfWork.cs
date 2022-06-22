using layihe.DAL.CityDAL;
using layihe.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
    public class CityUnitOfWork : ICityUnitOfWork
    {
        private readonly TestDbContext _testDbContext;
        public IDepartureCityRepository CityRepository { get; set; }
        public IArrivialCityRepository ArrivialCityRepository { get; set; }

        public CityUnitOfWork(TestDbContext testDbContext,IDepartureCityRepository cityRepository,IArrivialCityRepository arrivialCityRepository)
        {
            _testDbContext = testDbContext;
            CityRepository = cityRepository;
            ArrivialCityRepository = arrivialCityRepository;

        }
        public async Task Commit()
        {
           await _testDbContext.SaveChangesAsync();
        }
    }
}
